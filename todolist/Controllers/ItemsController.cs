﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository itemRepo;

		public ItemsController(IItemRepository thisRepo = null)
		{
			if (thisRepo == null)
			{
				this.itemRepo = new EFItemRepository();
			}
			else
			{
				this.itemRepo = thisRepo;
			}
		}


		public IActionResult Index()
		{
			return View(itemRepo.Items.ToList());
		}

		public IActionResult Details(int id)
		{
			var thisItem = itemRepo.Items.FirstOrDefault(items => items.ItemId == id);
			return View(thisItem);
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Index");
        }
		public IActionResult Edit(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}
		[HttpPost]
		public IActionResult Edit(Item item)
		{
			itemRepo.Edit(item);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}
		[HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			itemRepo.Remove(thisItem);
			return RedirectToAction("Index");
		}
        //[HttpGet, ActionName("Done")]
        //public IActionResult DoneTask(int id)
        //{
        //    //var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
        //    ////db.Items.Update(thisItem.Done = 1);
        //    //if (db.Items.thisItem.Done == false)
        //    //{
        //    //    db.Items.thisItem.Done = true;
        //    //}
        //    //db.SaveChanges();
        //    //return RedirectToAction("Index");
        //}
	}
}
