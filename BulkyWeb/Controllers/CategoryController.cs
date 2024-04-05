using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        // Now you should to assign the data what you get to your local variable _db that happens in line 16
        private readonly ApplicationDbContext _db;
      //In order to display the columns value from database to view page
      // You need to create constructor in that u need to pass that  I mean u need to pass the class of
      // data what you want to read  here I am getting from ApplicationDbcontext.cs
      // what ever data u will get u will get in db then follow line 9
        public CategoryController(ApplicationDbContext db) 
        {
            _db=db;
        }
        public IActionResult Index()
        {
            // Now you can retrive the values in view by

            //By this command you can get select * from tablename
            // it is converting the data variable _db into list 
          // var objCategoryList = _db.Categories.ToList();

            // since it is a list we can use
            List<Category> objCategoryList = _db.Categories.ToList();   // This is for retreviewing
            // here objCategoryList is an object
           
            // now you need to pass that object to in that view
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj) // Here ur creating again view for post and ur passing the categeory view obj
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "The Display order cannot exactly match the name.");
            }

            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }

            // ur adding a condition if is valid then send to db
            if (ModelState.IsValid)
            {


                _db.Categories.Add(obj);           // This is for creating like inseting  it also makes all the changes
                _db.SaveChanges(); // this is used to creste in db

               // used for creating temp data to display message
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
                return View();
            
            
        }

        // Creating for Edit Page
        public IActionResult Edit(int? id)
        {
            
            // Here it will check the id from Bulky datababes Category Column id 
            if(id == null || id == 0)
            {
                return NotFound();
            }
            // Here [_db.Categories] means line 28 we have used for select * from db here we used to find only coliumn id 
            Category? categoryFromDb = _db.Categories.Find(id);// this id u need to pass in edit view page in html // find only uses primary key
          
            // 2 other approaches
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj) // Here ur creating again view for post and ur passing the categeory view obj
        {
            

            // ur adding a condition if is valid then send to db
            if (ModelState.IsValid)
            {


                /*_db.Categories.Add(obj);  */         // This is for creating like inseting  it also makes all the changes
                _db.Categories.Update(obj); // here we use update it will update that category
                _db.SaveChanges(); // this is used to creste in db

                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();


        }

        // Deleting
        // Deleting the view
        public IActionResult Delete(int? id)
        {

            // Here it will check the id from Bulky datababes Category Column id 
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Here [_db.Categories] means line 28 we have used for select * from db here we used to find only coliumn id 
            Category? categoryFromDb = _db.Categories.Find(id);// this id u need to pass in edit view page in html // find only uses primary key

            // 2 other approaches
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) // Here ur creating again view for post and ur passing the categeory view obj
        {
            // first u need to find category from db
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);

           _db.SaveChanges(); // this is used to creste in db
            TempData["success"] = "Category deleted Successfully";
            return RedirectToAction("Index");
            
        }
        
    }
}
