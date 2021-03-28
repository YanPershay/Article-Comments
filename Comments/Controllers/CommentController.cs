using Article.Data.Interfaces;
using Comments.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetComments()
        {
            return Json(_commentRepository.AllComments);
        }

        [HttpPost]
        public IActionResult Index(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRepository.CreateComment(comment);
            }

            return View();
        }
    }
}
