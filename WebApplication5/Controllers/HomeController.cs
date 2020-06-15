using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        // GET: tDanhMucSPs
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var tDanhMucSPs = db.tDanhMucSPs.ToList().ToPagedList(pageNumber, pageSize);
            return View(tDanhMucSPs);
        }

        public ActionResult SPTheoMaSX(string id, int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var tDanhMucSPs = db.tDanhMucSPs.Where(x => x.MaHangSX == id).ToList().ToPagedList(pageNumber, pageSize);
            return View(tDanhMucSPs);
        }

        public ActionResult SPTheoQG(string id, int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var tDanhMucSPs = db.tDanhMucSPs.Where(x => x.MaNuocSX == id).ToList().ToPagedList(pageNumber, pageSize);
            return View(tDanhMucSPs);
        }

        // GET: tDanhMucSPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            if (tDanhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(tDanhMucSP);
        }

        // GET: tDanhMucSPs/Create
        public ActionResult Create()
        {
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.tHangSXes, "MaHangSX", "HangSX");
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs, "MaKichThuoc", "KichThuoc");
            ViewBag.MaDT = new SelectList(db.tLoaiDTs, "MaDT", "TenLoai");
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs, "MaLoai", "Loai");
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias, "MaNuoc", "TenNuoc");
            return View();
        }

        // POST: tDanhMucSPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,MaChatLieu,NganLapTop,Model,MauSac,MaKichThuoc,CanNang,DoNoi,MaHangSX,MaNuocSX,MaDacTinh,Website,ThoiGianBaoHanh,GioiThieuSP,Gia,ChietKhau,MaLoai,MaDT,Anh")] tDanhMucSP tDanhMucSP)
        {
            if (ModelState.IsValid)
            {
                db.tDanhMucSPs.Add(tDanhMucSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChatLieu = new SelectList(db.tChatLieux, "MaChatLieu", "ChatLieu", tDanhMucSP.MaChatLieu);
            ViewBag.MaHangSX = new SelectList(db.tHangSXes, "MaHangSX", "HangSX", tDanhMucSP.MaHangSX);
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs, "MaKichThuoc", "KichThuoc", tDanhMucSP.MaKichThuoc);
            ViewBag.MaDT = new SelectList(db.tLoaiDTs, "MaDT", "TenLoai", tDanhMucSP.MaDT);
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs, "MaLoai", "Loai", tDanhMucSP.MaLoai);
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias, "MaNuoc", "TenNuoc", tDanhMucSP.MaNuocSX);
            return View(tDanhMucSP);
        }

        // GET: tDanhMucSPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            if (tDanhMucSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux, "MaChatLieu", "ChatLieu", tDanhMucSP.MaChatLieu);
            ViewBag.MaHangSX = new SelectList(db.tHangSXes, "MaHangSX", "HangSX", tDanhMucSP.MaHangSX);
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs, "MaKichThuoc", "KichThuoc", tDanhMucSP.MaKichThuoc);
            ViewBag.MaDT = new SelectList(db.tLoaiDTs, "MaDT", "TenLoai", tDanhMucSP.MaDT);
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs, "MaLoai", "Loai", tDanhMucSP.MaLoai);
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias, "MaNuoc", "TenNuoc", tDanhMucSP.MaNuocSX);
            return View(tDanhMucSP);
        }

        // POST: tDanhMucSPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,MaChatLieu,NganLapTop,Model,MauSac,MaKichThuoc,CanNang,DoNoi,MaHangSX,MaNuocSX,MaDacTinh,Website,ThoiGianBaoHanh,GioiThieuSP,Gia,ChietKhau,MaLoai,MaDT,Anh")] tDanhMucSP tDanhMucSP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tDanhMucSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux, "MaChatLieu", "ChatLieu", tDanhMucSP.MaChatLieu);
            ViewBag.MaHangSX = new SelectList(db.tHangSXes, "MaHangSX", "HangSX", tDanhMucSP.MaHangSX);
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs, "MaKichThuoc", "KichThuoc", tDanhMucSP.MaKichThuoc);
            ViewBag.MaDT = new SelectList(db.tLoaiDTs, "MaDT", "TenLoai", tDanhMucSP.MaDT);
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs, "MaLoai", "Loai", tDanhMucSP.MaLoai);
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias, "MaNuoc", "TenNuoc", tDanhMucSP.MaNuocSX);
            return View(tDanhMucSP);
        }

        // GET: tDanhMucSPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            if (tDanhMucSP == null)
            {
                return HttpNotFound();
            }
            return View(tDanhMucSP);
        }

        // POST: tDanhMucSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tDanhMucSP tDanhMucSP = db.tDanhMucSPs.Find(id);
            db.tDanhMucSPs.Remove(tDanhMucSP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
