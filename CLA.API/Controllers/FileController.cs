using CLA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLA.API.Controllers
{
    public class FileController : BaseController
    {
        private readonly IFileService _fileService;
        public FileController(ILogger<TestUserMappingController> logger, IFileService fileService) : base(logger)
        {
            _fileService = fileService;
        }
    }
}
