using Forum.Application.Exceptions.Topics;
using Forum.Application.Topics;
using Forum.Application.Topics.Requests;
using Forum.Domain.Entities;
using Forum.Web.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forum.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;


        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var topics = await _topicService.GetAllAsync(cancellationToken);
            return View(topics);
        }
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAllForAdmin(CancellationToken cancellationToken)
        {
            var topics = await _topicService.GetAllForAdminAsync(cancellationToken);
            return View(topics);
        }
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var topic = await _topicService.GetAsync(cancellationToken, id);
            if (topic == null)
            {
                throw new TopicNotFound("Topic with this ID:" +  id + "was not found");
            }

            return View(topic);
        }
        public IActionResult Create()
        {
            return View();
        }

        /*[Authorize(Policy = "AdminAndUser")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(TopicRequestPostModel request, CancellationToken cancellationToken)
        {
            var topicToInsert = request.Adapt<Topic>();

            var errors = ModelState.Select(x => x.Value?.Errors)
             .Where(y => y.Count > 0).ToList();

            if (!ModelState.IsValid)
            {
                //ModelState.Clear(); 
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error[0].ErrorMessage);
                }
                return View("Share", "Error");

            }
            await _topicService.CreateAsync(cancellationToken, request);
            return RedirectToAction("GetAll");
        }*/
        [Authorize(Policy = "AdminAndUser")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(TopicRequestPostModel request, CancellationToken cancellationToken)
        {
            var topicToInsert = request.Adapt<Topic>();

            var errors = ModelState.Select(x => x.Value?.Errors)
             .Where(y => y.Count > 0).ToList();

            if (!ModelState.IsValid)
            {
                //ModelState.Clear(); 
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error[0].ErrorMessage);
                }
                return View(request);

            }
            try
            {
                await _topicService.CreateAsync(cancellationToken, request);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = ex.Message,
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                };

                return View("Error", errorViewModel);
            }

            return RedirectToAction("GetAll");
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> ApproveTopic(int id, CancellationToken cancellationToken)
        {
            await _topicService.ApproveTopicAsync(cancellationToken, id);
            return RedirectToAction(nameof(GetAllForAdmin));
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> RejectTopic(int id, CancellationToken cancellationToken)
        {
            await _topicService.RejectTopicAsync(cancellationToken, id);
            return RedirectToAction(nameof(GetAllForAdmin));
        }
    }
}





/* public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: Topic
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var topics = await _topicService.GetAllAsync(cancellationToken);
            return View(topics);
        }

        // GET: Topic/Details/5
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var topic = await _topicService.GetAsync(cancellationToken, id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopicRequestPostModel request, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _topicService.CreateAsync(cancellationToken, request);
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        // GET: Topic/Edit/5
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var topic = await _topicService.GetAsync(cancellationToken, id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TopicRequestPutModel requestDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _topicService.UpdateAsync(cancellationToken, requestDto);
                return RedirectToAction(nameof(Index));
            }

            return View(requestDto);
        }

        // GET: Topic/Delete/5
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var topic = await _topicService.GetAsync(cancellationToken, id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            await _topicService.GetAsync(cancellationToken, id);
            return RedirectToAction(nameof(Index));
        }
    }*/