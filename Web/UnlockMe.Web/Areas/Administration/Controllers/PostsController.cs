namespace UnlockMe.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using UnlockMe.Data;
    using UnlockMe.Data.Models;

    [Authorize(Roles = "Administrator")]
    public class PostsController : AdministrationController
    {
        private readonly ApplicationDbContext db;

        public PostsController(ApplicationDbContext context)
        {
            this.db = context;
        }

        // GET: Administration/Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.Posts.Include(p => p.AddedByUser).Include(p => p.Tag);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await db.Posts
                .Include(p => p.AddedByUser)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Administration/Posts/Create
        public IActionResult Create()
        {
            ViewData["AddedByUserId"] = new SelectList(db.Users, "Id", "Id");
            ViewData["TagId"] = new SelectList(db.Tags, "Id", "Id");
            return View();
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,TagId,AddedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Add(post);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedByUserId"] = new SelectList(db.Users, "Id", "Id", post.AddedByUserId);
            ViewData["TagId"] = new SelectList(db.Tags, "Id", "Id", post.TagId);
            return View(post);
        }

        // GET: Administration/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AddedByUserId"] = new SelectList(db.Users, "Id", "Id", post.AddedByUserId);
            ViewData["TagId"] = new SelectList(db.Tags, "Id", "Id", post.TagId);
            return View(post);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,TagId,AddedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(post);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedByUserId"] = new SelectList(db.Users, "Id", "Id", post.AddedByUserId);
            ViewData["TagId"] = new SelectList(db.Tags, "Id", "Id", post.TagId);
            return View(post);
        }

        // GET: Administration/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await db.Posts
                .Include(p => p.AddedByUser)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await db.Posts.FindAsync(id);
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return db.Posts.Any(e => e.Id == id);
        }
    }
}
