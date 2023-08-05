using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MindXLiveCodeGen8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateResume()
        {
            return default;
        }

        [HttpGet]
        public IActionResult GetAllResume()
        {
            return default;
        }

        [HttpGet("{resumeId}")]
        public IActionResult GetById(Guid resumeId)
        {
            return default;
        }

        [HttpPut]
        public IActionResult UpdateResume()
        {
            return default;
        }

        [HttpDelete]
        public IActionResult DeleteResume()
        {
            return default;
        }

        [HttpGet("download-resume")]
        public IActionResult DownloadResume()
        {
            return default;
        }
    }
}
