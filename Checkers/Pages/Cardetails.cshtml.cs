//using Core.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Newtonsoft.Json;

//namespace Checkers.Pages;
//public class DetailsModel : PageModel
//{

//    public Car Car { get; set; }

//    public IActionResult OnGet(string passedObject)
//    {

//        Car = JsonConvert.DeserializeObject<Car?>(passedObject);

//        if (Car == null)
//        {
//            return NotFound();
//        }

//        return Page();
//    }
//}