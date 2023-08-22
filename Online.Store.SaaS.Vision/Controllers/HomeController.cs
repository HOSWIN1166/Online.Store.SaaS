using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Online.Store.SaaS.Vision.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Online.Store.SaaS.Vision.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            const string baseUrl = "http://localhost:5069/Product";
            List<GetProductViewModel> products = new();

            using var client = new HttpClient();

            #region [- Config Http client items -]
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region [- Sending request to api -]
            //var responseMessage = await client.GetAsync("Get");
            var responseMessage = await client.GetAsync("");
            #endregion

            #region [- Recieving data from api -]
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<GetProductViewModel>>(response);
            }
            return View(products);
        }
        #endregion

        //#region [- Create() -]
        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    const string baseUrl = "http://localhost:5069/Product";
        //    List<GetProductViewModel> products = new();

        //    using var client = new HttpClient();

        //    #region [- Config Http client items -]
        //    client.BaseAddress = new Uri(baseUrl);
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    #endregion

        //    #region [- Sending request to api -]
        //    //var responseMessage = await client.GetAsync("Get");
        //    var responseMessage = await client.GetAsync("");
        //    #endregion

        //    #region [- Recieving data from api -]
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var response = responseMessage.Content.ReadAsStringAsync().Result;
        //        products = JsonConvert.DeserializeObject<List<GetProductViewModel>>(response);
        //    }
        //    #endregion

        //    return View(products);
        //}
        //#endregion

        //#region [- Edit() -]
        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    const string baseUrl = "http://localhost:5069/Product";
        //    List<GetProductViewModel> products = new();

        //    using var client = new HttpClient();

        //    #region [- Config Http client items -]
        //    client.BaseAddress = new Uri(baseUrl);
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    #endregion

        //    #region [- Sending request to api -]
        //    //var responseMessage = await client.GetAsync("Get");
        //    var responseMessage = await client.GetAsync("");
        //    #endregion

        //    #region [- Recieving data from api -]
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var response = responseMessage.Content.ReadAsStringAsync().Result;
        //        products = JsonConvert.DeserializeObject<List<GetProductViewModel>>(response);
        //    }
        //    #endregion

        //    return View(products);
        //}
        //#endregion

        //#region [- Delete() -]
        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    const string baseUrl = "http://localhost:5069/Product";
        //    List<GetProductViewModel> products = new();

        //    using var client = new HttpClient();

        //    #region [- Config Http client items -]
        //    client.BaseAddress = new Uri(baseUrl);
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    #endregion

        //    #region [- Sending request to api -]
        //    //var responseMessage = await client.GetAsync("Get");
        //    var responseMessage = await client.GetAsync("");
        //    #endregion

        //    #region [- Recieving data from api -]
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var response = responseMessage.Content.ReadAsStringAsync().Result;
        //        products = JsonConvert.DeserializeObject<List<GetProductViewModel>>(response);
        //    }
        //    #endregion

        //    return View(products);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}