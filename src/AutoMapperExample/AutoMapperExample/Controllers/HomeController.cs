using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapperExample.Dal;
using AutoMapper;
using ViewModels;

namespace AutoMapperExample.Controllers
{
    public class HomeController : Controller
    {
        MemberRepository _memberRepository = new MemberRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            var member = _memberRepository.GetMember(1);

            var viewModel = Mapper.Map<Member, WelcomeViewModel>(member);

            return View(viewModel);
        }

        public ActionResult Profile(int id)
        {
            var member = _memberRepository.GetMember(id);

            var viewModel = Mapper.Map<Member, ProfileViewModel>(member);

            viewModel.ProfilePictureUrl = GetProfileImageUrl(member.MemberId);

            return View(viewModel);
        }

        public ActionResult Members()
        {
            var members = _memberRepository.GetMembers();

            var viewModel = Mapper.Map<List<Member>, List<MembersViewModel>>(members);

            return View(viewModel);
        }

        private string GetProfileImageUrl(int id)
        {
            return string.Format("~/Images/Members/{0}/Profile", id);
        }
    }
}
