using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Independentsoft.Graph;
using System.Security.Cryptography;
using System.Text;
using Azure.Data.Tables.Models;
using Azure;
using Azure.Data.Tables;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using MSAuth.Model;
using RestSharp;
using Identity = MSAuth.Model.Identity;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace MSAuth.Controllers
{
    [Authorize]
    [RequiredScope("user_access")]
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private IConfiguration _configuration { get; set; }



        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API Called Successfully !!");
        }

      

   
    }
}
