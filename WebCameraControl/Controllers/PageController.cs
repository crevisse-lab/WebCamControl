﻿using Microsoft.AspNetCore.Mvc;
using WebCameraControl.Core;
using WebCameraControl.Models;

namespace WebCameraControl.Controllers;

public class PageController : Controller
{
    private readonly IConfiguration _configuration;

    public PageController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/pay")]
    public IActionResult Pay()
    {
        return View();
    }

    [HttpGet("/step-page")]
    public IActionResult StepPage()
    {
        return View();
    }

    [HttpGet("/select-page")]
    public IActionResult SelectPage()
    {
        return View();
    }

    [HttpGet("/printing")]
    public IActionResult Printing()
    {
        ViewData["url"] = "https://www.naver.com";

        return View();
    }

    [HttpPost("/check-password")]
    [ValidateAntiForgeryToken]
    public IActionResult CheckPassword([FromForm] string password)
    {
        string? appPassword = _configuration["Password"];

        if (password != appPassword)
        {
            return Unauthorized("Unauthorized!");
        }

        HttpContext.Session.SetString("IsPasswordChecked", "1");

        return Redirect("/take-picture");
    }

    [CheckLogin]
    [HttpGet("/guide")]
    public IActionResult Guide()
    {
        return View();
    }

    [CheckLogin]
    [HttpGet("/take-picture")]
    public IActionResult TakePicture()
    {
        return View(new IndexModel
        {
            CameraManufacturer = _configuration["CameraManufacturer"],
        });
    }

    [HttpGet("/testjj")]
    public IActionResult TestJJ()
    {
        return View();
    }
}
