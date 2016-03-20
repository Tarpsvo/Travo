﻿using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;
using Travo.DAL.Interfaces;
using Travo.DAL.Repositories;
using Travo.Domain.DTO;
using Travo.Filters;

namespace Travo.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : TravoApiController
    {
        private IAccountRepository _accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [AllowAnonymous]
        [Route("register"), HttpPost, ValidateModel]
        public async Task<IHttpActionResult> Register(RegisterDTO registerDTO)
        {
            IdentityResult result = await _accountRepository.RegisterUser(registerDTO);
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _accountRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
