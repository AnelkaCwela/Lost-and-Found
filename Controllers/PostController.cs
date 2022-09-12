using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Binding;
using LostNelsonFound.Models.Interface;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;

namespace LostNelsonFound.Controllers
{
    public class PostController : Controller
    {
        private byte[] DatAa { get; set; }
       
        private readonly IPersonModel _personModel;
        private readonly IFoundModel _foundModel;
       private readonly ILostModel _lostModel;
        private readonly IImageModel _imageModel;
        private readonly ICategoryLostModel _categoryLostModel;
        private readonly ICategoryModel _categoryModel;
        private readonly ICampus _campus;
        private readonly IBankCard _bankCard;
        private readonly IStatuseModel _statuseModel;
        private readonly IStatuseLostModel _statuseLostModel;
       private readonly IIdentityCard _identityCard;
        private readonly IStudentCard _studentCard;
        private readonly IClaimModel _claim;
        public PostController(IClaimModel claim,IStatuseLostModel statuseLostModel,IStatuseModel statuseModel, IImageModel imageModel,IStudentCard studentCard, IIdentityCard identityCard,IBankCard bankCard,ILostModel lostModel,ICampus campus,ICategoryModel categoryModel, ICategoryLostModel categoryLostModel,IPersonModel personModel, IFoundModel foundModel)
        {
            _claim = claim;
            _statuseLostModel = statuseLostModel;
            _imageModel = imageModel;
            _bankCard = bankCard;
            _identityCard = identityCard;
            _studentCard = studentCard;
            _lostModel = lostModel;
            _campus = campus;
            _categoryLostModel = categoryLostModel;
            _categoryModel = categoryModel;
            _statuseModel = statuseModel;
            _foundModel = foundModel;
            _personModel = personModel;
                
        }
        //
        [HttpGet]
        public async Task<IActionResult> Card(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                Guid idfound = new Guid(id);
                CardViewModel u = new CardViewModel();
                var Added = await _studentCard.GetByIdAsync(idfound);
                if (Added != null)
                {
                    u.iniatials = Added.iniatials;
                    u.Surname = Added.Suname;
                  //  ViewBag.CampusId = new SelectList((List<CampusModel>)await _campus.TabAsync(), "CampusId", "Campus");
                    return View(u);
                }

                var Aded = await _identityCard.GetByIdAsync(idfound);
                if (Aded != null)
                {
                    u.iniatials = Aded.iniatials;
                    u.Surname = Aded.Suname;
                    return View(u);
                }
                var Ad = await _bankCard.GetByIdAsync(idfound);
                if (Ad != null)
                {
                    u.iniatials = Ad.iniatials;
                    u.Surname = Ad.Surname;
                    return View(u);
               }


            }

            return RedirectToAction("Error", "Home");
        }
        
        [HttpGet]
       //form view of lost item form
        public async Task<IActionResult> Lost()
        {
            //Upload combobox / listbox in lost form
            ViewBag.CategoryLostId = new SelectList((List<CategoryLostModel>)await _categoryLostModel.TabAsync(), "CategoryLostId", "CategoryLostName");
            ViewBag.CampusId = new SelectList((List<CampusModel>)await _campus.TabAsync(), "CampusId", "Campus");
            return View();
        }
        [HttpGet]
        //form view of found form
        public async Task<IActionResult> Found()
        {
            //Upload combobox / listbox in found form
            ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
           
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //post form of  lost items
        public async Task<IActionResult> Lost(LostInsertModel Model)
        {
            //check if the form is valid
            if (ModelState.IsValid)
            {
                //check if user is login
                if (User.Identity.Name != null)
                {
                   

                    LostModel Info = new LostModel();
                    //get logined user , user details
                    string user = User.Identity.Name;
                   
                    Guid StatuseId = new Guid("27E0ED46-15C1-44DC-6823-08D935C2FCA3");
                    //get user details
                    var person = await _personModel.GetByEmailAsync(user);
                    if(person==null)
                    {
                        //if tracking user  is null ,create user  using  
                        PersonModel personn = new PersonModel();
                        personn.UserName = User.Identity.Name;
                        
                        PersonModel inu =  await _personModel.AddAsync(personn);
                        person.PersonId= inu.PersonId;
                    }
                    
                    LostModel Data = 
                        new LostModel();

                    Data.PhoneNumber = Model.PhoneNumber;
                    Data.EmailAddress = Model.EmailAddress;
                    Data.CampusId = Model.CampusId;
                    Data.CategoryLostId = Model.CategoryLostId;
                    Data.DateFound = DateTime.Now;
                    Data.DatePosted = DateTime.Now;
                    Data.LostDate = Model.LostDate;
                    Data.LostDescription = Model.LostDescription;
                    Data.StatuseLostId = StatuseId;              
                    Data.PersonId = person.PersonId;
                    Data.Location = Model.Location;
                    Data.tip = Model.tip;

                    try
                    {
                        //insert lost details from the form
                        Info = await _lostModel.AddAsync(Data);
                     
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    //generate link of item posted 
                    var Link = Url.Action("Detail", "Post", new { id = Info.LostId }, Request.Scheme, Request.Host.ToString());
                    string Email = "s220006415@mandela.ac.za";//email address to destination wish will send to all staff and student , so far will be using  this email
                    try
                    {

                        //call method sendAll , will sent to all , people , with parameters date
                        await SendAll(Email, Link, Info.LostDate, Info.Location);
                    }
                    catch
                    {
                        // if any error
                        return RedirectToAction("Error", "Home");
                    }
                    return RedirectToAction("Infomation", "Post");


                }

            }
            //load  select list/combo box if  post method was not successfull
            ViewBag.CategoryLostId = new SelectList((List<CategoryLostModel>)await _categoryLostModel.TabAsync(), "CategoryLostId", "CategoryLostName");
            ViewBag.CampusId = new SelectList((List<CampusModel>)await _campus.TabAsync(), "CampusId", "Campus");
            return View(Model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //found form post
        public async Task<IActionResult> Found(FoundInsertModel foundInsertModel)       
        {
            //valided  form  from found form field 
            Guid FF = new Guid("00000000-0000-0000-0000-000000000000");
            if(foundInsertModel.Description==null)
            {
                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                return View(foundInsertModel);
            }
            if(foundInsertModel.CategoryId==FF)
            {
                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                ViewBag.category = "Select Category";
                return View(foundInsertModel);
            }
            if(foundInsertModel.DateFound==null)
            {
                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                return View(foundInsertModel);
            }
            if(foundInsertModel.Location==null)
            {
                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                return View(foundInsertModel);
            }
            if(foundInsertModel.PhoneNumber==null)
            {
                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                return View(foundInsertModel);
            }
            if (foundInsertModel.EmailAddress == null)
            {
                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                return View(foundInsertModel);
            }
            else
            {
                //check if login user valid
                if (User.Identity.Name != null)
                {
                    ImageModel image = new ImageModel();
                    FoundModel Info = new FoundModel();
                  
                    //get all image / photo selected
                    foreach (var file in Request.Form.Files)
                    {
                        //if (file.Length > 1024 * 1024)
                        //{
                        //    ViewBag.size = "Size of image is too large";
                        //    ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                        //    return View(foundInsertModel);
                        //}
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        DatAa = ms.ToArray();
                        try
                        {
                            //check the file type selected if is png/jpn
                            var supported = new[] { "png", "jpg","PNG","JPG" };
                            var f = Path.GetExtension(file.FileName).Substring(1);
                            if(!supported.Contains(f))
                            {
                               
                               // ModelState.AddModelError("","png or jpn file format required");
                                ViewBag.file = "png or jpn file format required";
                                ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                                return View(foundInsertModel);
                            }
                           
                        }
                        catch
                        {
                            return RedirectToAction("Error", "Home");
                        }
                     
                        if (DatAa == null)
                        {
                            //valided if the is file uploaded 
                            ViewBag.Added = "Take Pictuse of Item and upload it";
                            ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
                            return View(foundInsertModel);
                        }
                        break;
                    }
                    
                    PersonModel R = new PersonModel();
                    foundInsertModel.PhotoFound = DatAa;
                    string user = User.Identity.Name;
                    Guid StatuseId = new Guid("7ADC84E9-1597-46F4-07E3-08D935C2CED4");
                   
                    PersonModel use = await _personModel.GetByEmailAsync(user); //get user info loged in 
                    if (use == null)
                    {
                       
                        R.UserName = user;
                        //if user info is null , create poson
                        use = await _personModel.AddAsync(R);
                
                    }
                    
                    FoundModel Data = new FoundModel();              
                    Data.CategoryId = foundInsertModel.CategoryId;
                    Data.EmailAddress = foundInsertModel.EmailAddress;
                    Data.PhoneNumber = foundInsertModel.PhoneNumber;
                    Data.DateFound = foundInsertModel.DateFound;
                    Data.DatePosted = DateTime.Now;
                    Data.Description = foundInsertModel.Description;
                    Data.StatuseId = StatuseId;
                    
                    Data.PersonId = use.PersonId;
                    Data.Location = foundInsertModel.Location;
                    Data.PhotoFound = DatAa;

                    try
                    {
                        //insert infomation of found method
                        Info = await _foundModel.AddAsync(Data);
                    }
                    catch
                    {
                        return RedirectToAction("Error", "Home");
                    }


                    foreach (var file in Request.Form.Files)
                    {
                        MemoryStream ms = new MemoryStream();

                        file.CopyTo(ms);
                        DatAa = ms.ToArray();

                        image.ImageData = DatAa;
                        image.FoundId = Info.FoundId;

                        try
                        {
                            await _imageModel.AddAsync(image);
                        }
                        catch
                        {
                            return RedirectToAction("Error", "Home");
                        }

                    }
                    Guid StudentStaffCradid = new Guid("D37E0883-B6C6-46DF-C97F-08D935C07142");
                    Guid LicenceIdCardid = new Guid("F1A1010C-9255-41BC-C980-08D935C07142");
                    Guid BankCardid = new Guid("95352595-69AD-46F2-C987-08D935C07142");
                    //check catgory of item select of same simmilarties
                    if (StudentStaffCradid == Info.CategoryId)
                    {
                        StudentCardModel model = new StudentCardModel();
                        model.FoundId = Info.FoundId;
                        
                        //student card , staff card form
                        //if category of item selected is studecard or , staff card redirect to student card form details , so user can insert student card details
                        return RedirectToAction("StudentCard", "Post", model);
                    }
                    else if (LicenceIdCardid == Info.CategoryId)
                    {
                        IdentityCardModel model = new IdentityCardModel();
                        model.FoundId = Info.FoundId;
                        //licence card , identity card form
                        //if category of item selected is indentity card redirect to identity  card form details , so user can insert indentity card details
                        return RedirectToAction("IdentityCard", "Post", model);
                    }
                    else if (BankCardid == Info.CategoryId)
                    {
                        BankCardModel model = new BankCardModel();
                        model.FoundId = Info.FoundId;
                        //bank card details
                        //if category of item selected is bank card redirect to bank card form details , so user can insert b card details
                        return RedirectToAction("BankCard", "Post", model);
                    }
                    else
                    {
                        //if the is no card detais need to be entered  ,gerate link and send notifying emaal
                        var Link = Url.Action( "Details", "Post", new { id = Info.FoundId }, Request.Scheme, Request.Host.ToString());
                        string Email = "s220006415@mandela.ac.za";
                        await SendAll(Email,Link, Info.DateFound,Info.Location);
                        
                        return RedirectToAction("Infomation", "Post");
                    }
                  


                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }

            }
      
        }
        public IActionResult Index()
        {
            return View();
        }


      [HttpPost]
      [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IdentityCard(IdentityCardModel model, string id)
        {
            //check if field are valid
            if(ModelState.IsValid)
            {
                try
                {
                    //insert card details enterd
                    await _identityCard.AddAsync(model);
                }
                catch
                {
                    ViewBag.Added = "Somthing went wrong , try again";
                    return View(model);
                }
                //gerate link of card details
                
                var Link = Url.Action( "Details","Post", new { id = model.FoundId }, Request.Scheme, Request.Host.ToString());
                try
                {
                    // if student card details enterd  , take student number  , and create  email details using 
                   
                    string emai = model.Name + "." + model.Suname + "@mandela.ac.za";
                   await SendId(emai, Link, model.Name, model.Suname);
                }
                catch
                {
                    //the will be error if student number entred , since student number is no valid , we will send it all univesity student
                    try
                    {
                        //All Nelson Maandela student
                        string too = "s220006415@mandela.ac.za";
                        await SendStudentStaff(too, Link);
                    }
                    catch
                    {
                        return RedirectToAction("Infomation", "Post");
                    }
                }
                
                return RedirectToAction("Infomation", "Post");
            }
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> StudentCard(StudentCardModel model, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _studentCard.AddAsync(model);
                }
                catch
                {
                    ViewBag.Added = "Somthing went wrong , try again";
                    return View(model);
                }
                var Link = Url.Action("Details","Post", new { id = model.FoundId }, Request.Scheme, Request.Host.ToString());
                if (model.staffStudentModel.ToString()== "Student")
                {
                    //  var Link = Url.Action("Post", "Details", new { id = model.FoundId }, Request.Scheme, Request.Host.ToString());
                    string to = "s" + model.StudentNo + "@mandela.ac.za";
                    try
                    {
                        await SendToStudent(to, Link, model.Suname, model.iniatials.ToString());
                    }
                    catch
                    {
                        try
                        {
                            //All Nelson Maandela student
                            string too = "s220006415@mandela.ac.za";
                            await SendStudentStaff(too, Link);
                        }
                        catch
                        {
                            return RedirectToAction("Infomation", "Post");
                        }
                    }
                }
                else
                {
                    try
                    {
                        //All Nelson Maandela Staff
                        string too = "s220006415@mandela.ac.za";
                        await SendStudentStaff(too, Link);
                    }
                    catch
                    {
                        return RedirectToAction("Infomation", "Post");
                    }
                }
        
                    return RedirectToAction("Infomation", "Post");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Infomation()
        {
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            //check if  route id is not null
            if(id==null)
            {
                return RedirectToAction("Error", "Home");
            }
            // change string to guid id
            Guid idfound = new Guid(id);
            FoundModeldopleCate Data = new FoundModeldopleCate();
            FoundModel Data1= await _foundModel.GetByIdAsync(idfound);//  get found details using  id
            if(Data1==null)// if id dont exist , redirect to error
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
              
                Data.EmailAddress = Data1.EmailAddress;
                Data.StatuseId = Data1.StatuseId;
                Data.Location = Data1.Location;
                Data.PhoneNumber = Data1.PhoneNumber;
                Data.CategoryId = Data1.CategoryId;
                Data.StatuseId = Data1.StatuseId;
                Data.DateFound = Data1.DateFound;
                Data.Description = Data1.Description;
                Data.PhotoFound = Data1.PhotoFound;
                Data.FoundId = Data1.FoundId;
                Data.DatePosted = Data1.DatePosted;
                Guid StudentStaffCradid = new Guid("D37E0883-B6C6-46DF-C97F-08D935C07142");
                Guid LicenceIdCardid = new Guid("F1A1010C-9255-41BC-C980-08D935C07142");
                Guid BankCardid = new Guid("95352595-69AD-46F2-C987-08D935C07142");
               
                if (StudentStaffCradid == Data.CategoryId) //check category of item
                {
                    var Added = await _studentCard.GetBy_Id_Async(Data.FoundId);
                    if (Added != null)
                    {
                        Data.FoundIs = true;
                        Data.Id = Added.StudentId;
                    }
                }
                else if (LicenceIdCardid == Data.CategoryId)
                {
                    var Added = await _identityCard.GetBy_Id_Async(Data.FoundId);
                    if (Added != null)
                    {
                        Data.FoundIs = true;
                        Data.Id = Added.IdentyCardId;
                    }
                }
                else if (BankCardid == Data.CategoryId)
                {
                    var Added = await _bankCard.GetBy_Id_Async(Data.FoundId);
                    if (Added != null)
                    {
                        Data.FoundIs = true;
                        Data.Id = Added.BankCardId;

                    }
                }
               

            }
            ViewBag.CategoryId = new SelectList((List<CategoryModel>)await _categoryModel.TabAsync(), "CategoryId", "CategoryName");
            ViewBag.StatuseId = new SelectList((List<StatuseModel>)await _statuseModel.TabAsync(), "StatuseId", "Statuse");
            return View(Data);

        }
       
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            //get route id of item
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Guid idLost = new Guid(id);
            LostModel Data = await _lostModel.GetByIdAsync(idLost);//get item details by route id
            if (Data == null)
            {
                return RedirectToAction("Error", "Home");
            }

            ViewBag.CategoryLostId = new SelectList((List<CategoryLostModel>)await _categoryLostModel.TabAsync(), "CategoryLostId", "CategoryLostName");
            ViewBag.StatuseLostId = new SelectList((List<StatuseLostModel>)await _statuseLostModel.TabAsync(), "StatuseLostId", "LostStatuse");
            ViewBag.CampusId = new SelectList((List<CampusModel>)await _campus.TabAsync(), "CampusId", "Campus");
            return View(Data);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> BankCard(BankCardModel model, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _bankCard.AddAsync(model);//instert card details
                }
                catch
                {
                    ViewBag.Added = "Somthing went wrong , try again";
                    return View(model);

                }

                try
                {
                    //send notify email to all staff and student
                    string Email = "s220006415@mandela.ac.za";
                    var Link = Url.Action( "Details", "Post", new { id = model.FoundId }, Request.Scheme, Request.Host.ToString());
                    await SendStudentStaff(Email, Link);
                }
                catch
                {
                    return RedirectToAction("Infomation", "Post");
                }

                return RedirectToAction("Infomation", "Post");
            }
            return View(model);

        }


        //genarate email that will be sent to student directly , student that has student number
        public async Task<RedirectToActionResult> SendToStudent(string To, string confirmationLink,string Surname ,string intials)
        {

            string Subject = "Lost And Found";
            //string body = confirmationLink;
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Good day  "+intials+" "+Surname+"</p1></br></br>"
                + "<p2>If you have lost an item</p2>" +
"<p3>Please click the link below, to check the details <span><a href = " + confirmationLink + ">Click hear</a></span></p3>" +
         "<br/><p5><br/> Kindly Regards</p5> <br/>Lost and Found Tearm";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("infoslostfound@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("infoslostfound@gmail.com", "Password");

            
                await smtp.SendMailAsync(Mail);
          
            return RedirectToAction("Infomation", "Post");


        }
        //gerate email that will be be sent to staff and student
        public async Task<RedirectToActionResult> SendStudentStaff(string To, string message)
        {

            string Subject = "Lost and Found";
            //string body = confirmationLink;
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Good day Staff and Student </p1></br></br>"
                + "<p2>If you have lost an item</p2>" +
"<p3>Please click the link below, to check the details <span><a href = " + message + ">Click hear</a></span></p3>" +
         "<br/><p5><br/> Kindly Regards</p5> <br/>Lost and Found Tearm";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("infoslostfound@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("infoslostfound@gmail.com", "Password");

          
                await smtp.SendMailAsync(Mail);
           
            return RedirectToAction("Infomation", "Post");


        }
        //
        public async Task<RedirectToActionResult> SendId(string To, string message,string Name ,string Surname)
        {

            string Subject = "Lost and Found";
            //string body = confirmationLink;
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Good day  " + Surname + " " + Name + "</p1></br></br>"
               + "<p2>If you have lost an item</p2>" +
"<p3>Please click the link below, to check the details <span><a href = " + message + ">Click hear</a></span></p3>" +
        "<br/><p5><br/> Kindly Regards</p5> <br/>Lost and Found Tearm";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("infoslostfound@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("infoslostfound@gmail.com", "Password");

           
                await smtp.SendMailAsync(Mail);
           
            return RedirectToAction("Infomation", "Post");


        }
        //genarete emaill thatill be sent to all staff and student
        public async Task<RedirectToActionResult> SendAll(string To, string message, DateTime ItemDescre,string Location)
        {

            string Subject = "Lost and Found";
            //string body = confirmationLink;
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Good day All </p1></br></br>"
               + "<p2>The is New item found or Lost</p2>" +
 "<p3>Please click the link below, to check the details of item  on " + ItemDescre+" in "+Location+" <span><a href = " + message + ">Click hear</a></span></p3>" +
        "<br/><p5><br/> Kindly Regards</p5> <br/>Lost and Found Tearm";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("infoslostfound@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("infoslostfound@gmail.com", "Passowrd");

            
                await smtp.SendMailAsync(Mail);
          
           return RedirectToAction("Infomation", "Post");

        }

        [HttpGet]
        public IActionResult IdentityCard(IdentityCardModel model)
        {
           //get form view cointaing item id
                return View(model);
          
        }
        [HttpGet]
        public async Task<IActionResult> AClaims()///get list of all claims
        {
            List<ClaimModel> model = (List<ClaimModel>)await _claim.TabAsync();

            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> StudentCard(StudentCardModel model)
        {
            ViewBag.CampusId = new SelectList((List<CampusModel>)await _campus.TabAsync(), "CampusId", "Campus");
            return View(model);
        }
        [HttpGet]
        public IActionResult BankCard(BankCardModel model)
        {
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> LostList()        ///List of item posted
        {
            Guid id = new Guid("27E0ED46-15C1-44DC-6823-08D935C2FCA3");// guid id of  active post statuse
            List<LostModel> Info = (List<LostModel>)await _lostModel.GetByActiveAsync(id);// select all lost post with active statuse
            List<CampusModel> Info2 = (List<CampusModel>)await _campus.TabAsync();
            List<StatuseLostModel> Info3 = (List<StatuseLostModel>)await _statuseLostModel.TabAsync();
            List<CategoryLostModel> Info4 = (List<CategoryLostModel>)await _categoryLostModel.TabAsync();
            
            var combineTible = from c in Info
                               join ct in Info2 on c.CampusId equals ct.CampusId into tab1
                               from ct in tab1.DefaultIfEmpty()

                               join ct1 in Info3 on c.StatuseLostId equals ct1.StatuseLostId into tab2
                               from ct1 in tab2.DefaultIfEmpty()

                               join ct2 in Info4 on c.CategoryLostId equals ct2.CategoryLostId into tab3
                               from ct2 in tab3.DefaultIfEmpty()
                               select new LostListViewModel
                               {

                                   LostModel = c,
                                   CategoryModel = ct2,
                                   statuseModel = ct1,
                                   CampusMode=ct

                               };

            return View(combineTible);

        }
        [HttpGet]
        public async  Task<IActionResult> FoundList()//list of active found list
        {
            Guid id = new Guid("7ADC84E9-1597-46F4-07E3-08D935C2CED4");// guid id of  active post statuse

            List<FoundModel> Info = (List<FoundModel>)await _foundModel.GetByActiveAsync(id);//get all found item with active statuse
            List<CategoryModel> Info2 = (List<CategoryModel>)await _categoryModel.TabAsync();
            List<StatuseModel> Info3 = (List<StatuseModel>)await _statuseModel.TabAsync();
          
            var combineTible = from c in Info
                               join ct in Info2 on c.CategoryId equals ct.CategoryId into tab1
                               from ct in tab1.DefaultIfEmpty()

                               join ct1 in Info3 on c.StatuseId equals ct1.StatuseId into tab2
                               from ct1 in tab2.DefaultIfEmpty()

                               select new FoundListViewModel
                               {
                                  
                                   FoundModel = c,
                                   CategoryModel = ct,
                                   statuseModel= ct1
                                 
                               };

            return View(combineTible);

        }

        [HttpGet]
        public async Task<IActionResult> Removes(string id)//change lost item statuse to inactive
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Guid idLost = new Guid(id);
            LostModel Data = await _lostModel.GetByIdAsync(idLost);
            if (Data == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                Guid deleteid = new Guid("249C8BCD-BF42-4D0C-684B-08D935D6ADEE");//guid id statuse inactive
                Data.StatuseLostId = deleteid;
                try
                {

                    await _lostModel.RemoveAsync(Data);
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("PostL", "Post");
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string id)//change found item statuse Inactive
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Guid idfound = new Guid(id);
            FoundModel Data = await _foundModel.GetByIdAsync(idfound);
            if (Data == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                Guid deleteid = new Guid("249C8BCD-BF42-4D0C-684B-08D935D6ADEE");//guid id found item to inactive
                Data.StatuseId = deleteid;

                try
                {
                    await _foundModel.RemoveAsync(Data);
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("PostF", "Post");
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Claim(ClaimModel model)// claim item detail
        {

            if(ModelState.IsValid)
            {
                FoundModel Data = new FoundModel();
                try
                {
                    Guid deleteid = new Guid("4BE4B480-3230-493F-07E2-08D935C2CED4");//  guid statuse id  item statuse to inactive ,
                     Data.StatuseId = deleteid;
                    Data.FoundId = model.FoundId;


                    model.IsOwner = true;
                  
                    
                    await _claim.AddAsync(model);
                    await _foundModel.RemoveAsync(Data);// remove item to inative
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("Infomation", "Post");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Claim(string id)// get item and claim details
        {
            ClaimModel clai = new ClaimModel();
            if (User.Identity.Name!=null)
            {
                if (id == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                Guid idfound = new Guid(id);
                FoundModel Data = await _foundModel.GetByIdAsync(idfound);
                if (Data == null)
                {
                    return RedirectToAction("Error", "Home");
                }
              

                clai.FoundId = Data.FoundId;
               
               
             

            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            return View(clai);
        }




        [HttpGet]
        public async Task<IActionResult> PostF()// get all his personal found  item posted by the self 
        {
            if (User.Identity.Name != null)
            {
                Guid id = new Guid("7ADC84E9-1597-46F4-07E3-08D935C2CED4");// guid id of active post
                var person = await _personModel.GetByEmailAsync(User.Identity.Name);
                List<FoundModel> Info = (List<FoundModel>)await _foundModel.GetByUserAsync(id, person.PersonId);// get all personaly post where item are posted by him self and item statuse is active
                List<CategoryModel> Info2 = (List<CategoryModel>)await _categoryModel.TabAsync();
                List<StatuseModel> Info3 = (List<StatuseModel>)await _statuseModel.TabAsync();

                var combineTible = from c in Info
                                   join ct in Info2 on c.CategoryId equals ct.CategoryId into tab1
                                   from ct in tab1.DefaultIfEmpty()

                                   join ct1 in Info3 on c.StatuseId equals ct1.StatuseId into tab2
                                   from ct1 in tab2.DefaultIfEmpty()

                                   select new FoundListViewModel
                                   {

                                       FoundModel = c,
                                       CategoryModel = ct,
                                       statuseModel = ct1

                                   };

                return View(combineTible);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PostL()//get all personal item posted
        {
            if(User.Identity.Name!=null)
            {
                Guid id = new Guid("27E0ED46-15C1-44DC-6823-08D935C2FCA3");//guid id statuse active
                var person = await _personModel.GetByEmailAsync(User.Identity.Name);
                List<LostModel> Info = (List<LostModel>)await _lostModel.GetByUserAsync(id,person.PersonId);// get all personaly post where item are posted by him self and item statuse is active
                List<CampusModel> Info2 = (List<CampusModel>)await _campus.TabAsync();
                List<StatuseLostModel> Info3 = (List<StatuseLostModel>)await _statuseLostModel.TabAsync();
                List<CategoryLostModel> Info4 = (List<CategoryLostModel>)await _categoryLostModel.TabAsync();

                var combineTible = from c in Info
                                   join ct in Info2 on c.CampusId equals ct.CampusId into tab1
                                   from ct in tab1.DefaultIfEmpty()

                                   join ct1 in Info3 on c.StatuseLostId equals ct1.StatuseLostId into tab2
                                   from ct1 in tab2.DefaultIfEmpty()

                                   join ct2 in Info4 on c.CategoryLostId equals ct2.CategoryLostId into tab3
                                   from ct2 in tab3.DefaultIfEmpty()
                                   select new LostListViewModel
                                   {

                                       LostModel = c,
                                       CategoryModel = ct2,
                                       statuseModel = ct1,
                                       CampusMode = ct

                                   };

                return View(combineTible);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Statuses(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Guid idLost = new Guid(id);
            LostModel Data = await _lostModel.GetByIdAsync(idLost);
            if (Data == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                Guid deleteid = new Guid("69019E0A-1422-4566-6824-08D935C2FCA3");
                Data.StatuseLostId = deleteid;
                try
                {

                    await _lostModel.RemoveAsync(Data);
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("PostF", "Post");
            }


        }

        
        [HttpGet]
        public async Task<IActionResult> Deletes(string id)//delete lost permantly item  selected
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Guid idLost = new Guid(id);
            LostModel Data = await _lostModel.GetByIdAsync(idLost);
            if (Data == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
               
                try
                {

                    await _lostModel.RemoveAsync(Data.LostId);
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("LostHistory", "Post");
            }


        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)//delete found permantly item  selected
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Guid idfound = new Guid(id);
            FoundModel Data = await _foundModel.GetByIdAsync(idfound);
            if (Data == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                

                try
                {
                    await _foundModel.RemoveAsync(Data.FoundId);
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("FoundHistory", "Post");
            }
        }



        [HttpGet]
        public async Task<IActionResult> LostHistory()// gell item active and in active
        {

            List<LostModel> Info = (List<LostModel>)await _lostModel.TabAsync();
            List<CampusModel> Info2 = (List<CampusModel>)await _campus.TabAsync();
            List<StatuseLostModel> Info3 = (List<StatuseLostModel>)await _statuseLostModel.TabAsync();
            List<CategoryLostModel> Info4 = (List<CategoryLostModel>)await _categoryLostModel.TabAsync();

            var combineTible = from c in Info
                               join ct in Info2 on c.CampusId equals ct.CampusId into tab1
                               from ct in tab1.DefaultIfEmpty()

                               join ct1 in Info3 on c.StatuseLostId equals ct1.StatuseLostId into tab2
                               from ct1 in tab2.DefaultIfEmpty()

                               join ct2 in Info4 on c.CategoryLostId equals ct2.CategoryLostId into tab3
                               from ct2 in tab3.DefaultIfEmpty()
                               select new LostListViewModel
                               {

                                   LostModel = c,
                                   CategoryModel = ct2,
                                   statuseModel = ct1,
                                   CampusMode = ct

                               };

            return View(combineTible);

        }




        [HttpGet]

        public async Task<IActionResult> FoundHistory()//list of all item  active and inative
        {


            List<FoundModel> Info = (List<FoundModel>)await _foundModel.TabAsync();
            List<CategoryModel> Info2 = (List<CategoryModel>)await _categoryModel.TabAsync();
            List<StatuseModel> Info3 = (List<StatuseModel>)await _statuseModel.TabAsync();

            var combineTible = from c in Info
                               join ct in Info2 on c.CategoryId equals ct.CategoryId into tab1
                               from ct in tab1.DefaultIfEmpty()

                               join ct1 in Info3 on c.StatuseId equals ct1.StatuseId into tab2
                               from ct1 in tab2.DefaultIfEmpty()

                               select new FoundListViewModel
                               {

                                   FoundModel = c,
                                   CategoryModel = ct,
                                   statuseModel = ct1

                               };

            return View(combineTible);

        }

        
    }
}
