using BinaryTranslator.Models;
using Microsoft.AspNetCore.Mvc;
using BinaryTranslator.Services;

namespace BinaryTranslator.Controllers;

public class HomeController : Controller
{
    private readonly IBinaryConverter binaryConverter;

    public HomeController(IBinaryConverter binaryConverter) => this.binaryConverter = binaryConverter;

    public IActionResult Index()
    {
        return View(new BaseModel());
    }

    [HttpPost]
    public IActionResult Index(BaseModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return View(model);
        }
        
        var inputData = model.Data.Trim().Replace(" ", "");

        if (this.binaryConverter.IsBinary(inputData))
        {
            var binary = this.binaryConverter.BinaryToString(inputData);
            var responseModel = new BaseModel
            {
                Data = binary
            };
            return View(responseModel);
        }

        var text = this.binaryConverter.StringToBinary(inputData);
        var responseModel2 = new BaseModel
        {
            Data = text
        };
        return View(responseModel2);
    }
}