using Microsoft.AspNetCore.Mvc;

namespace ViewComponent_Practice.Components
{
    public class CourseSummary : ViewComponent
    {
        //Syntax to pass hard coded data

        //public string Invoke(int count) 
        //{
        //    return "Hello"+count;
        //}

        //Synchoronus Function 


        //public IViewComponentResult Invoke()
        //{
        //    return View();

        //}


        //Asyncronous Function

        public async Task<IViewComponentResult> InvokeAsync() 
        {

            return View();
        }

    }
}
