using DesafioIClips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioIClips.Controllers
{
    public class HomeController : Controller
    {
        public static List<Person> People { get; set; }

        //constructor, initialize List
        public HomeController()
        {
            populatePeople();
        }

        //Home Page Action
        public ActionResult Index()
        {
            //Sending Title, counters and populated list of persons to view("Index")
            ViewBag.Title = "Todos";
            ViewBag.BadgeAndamentoCounter = People.Where(x => x.Situacao == EnumSituacao.Atrasado).ToList().Count;
            ViewBag.BadgeAtrasadoCounter = People.Where(x => x.Situacao == EnumSituacao.Andamento).ToList().Count;
            ViewBag.BadgePeopleCounter = People.Count();
            return View();
        }

        //Em Andamento Page Action
        public ActionResult Andamento()
        {
            //Sending Title, counters and populated list to view("Index")
            ViewBag.Title = "Andamento";
            ViewBag.BadgeAndamentoCounter = People.Where(x => x.Situacao == EnumSituacao.Andamento).ToList().Count;
            ViewBag.BadgeAtrasadoCounter = People.Where(x => x.Situacao == EnumSituacao.Atrasado).ToList();
            ViewBag.BadgePeopleCounter = People.Count();
            ViewBag.People = People.Where(x => x.Situacao == EnumSituacao.Andamento).ToList();
            return View("Index");
        }

        //Atrasados Page Action
        public ActionResult Atrasado()
        {         
            //Sending Title, counters and populated list to view("Index")
            ViewBag.Title = "Atrasado";
            ViewBag.BadgeAndamentoCounter = People.Where(x => x.Situacao == EnumSituacao.Atrasado).ToList().Count;
            ViewBag.BadgeAtrasadoCounter = People.Where(x => x.Situacao == EnumSituacao.Andamento).ToList().Count;
            ViewBag.BadgePeopleCounter = People.Count();
            ViewBag.People = People.Where(x => x.Situacao == EnumSituacao.Atrasado).ToList();
            return View("Index");
        }

        //Sort wanted list by name and return data to view as json.
        [HttpPost]
        public JsonResult OrderTable(string Title)
        {
            //get the title parameter to check wich list is needed.
            List<Person> orderedPeople = new List<Person>();
            //every person`s list.
            if(Title == "Todos")
            {
                orderedPeople = People.OrderBy(s => s.Nome).ToList();
            //atrasado`s list
            }else if(Title == "Atrasado")
            {
                List<Person> atrasados = People.Where(x => x.Situacao == EnumSituacao.Atrasado).ToList();
                orderedPeople = atrasados.OrderBy(s => s.Nome).ToList();
            //em andamento`s list
            }else
            {
                List<Person> andamento = People.Where(x => x.Situacao == EnumSituacao.Andamento).ToList();
                orderedPeople = andamento.OrderBy(s => s.Nome).ToList();
            }
            //return as a json array
            return Json(orderedPeople);
        }

        //Initialize List
        public void populatePeople()
        {
            People = new List<Person>
            {
                new Person { Nome = "David Koch", Email = "david@gmail.com", Situacao = EnumSituacao.Andamento },
                new Person { Nome = "Charles Koch", Email = "Koch@gmail.com", Situacao = EnumSituacao.Atrasado },
                new Person { Nome = "Michael Bloomberg", Email = "bloomberg@gmail.com", Situacao = EnumSituacao.Atrasado },
                new Person { Nome = "Larry Ellison", Email = "larry@gmail.com", Situacao = EnumSituacao.Atrasado },
                new Person { Nome = "Mark Zuckerberg", Email = "mark@gmail.com", Situacao = EnumSituacao.Atrasado },
                new Person { Nome = "Jeff Bezos", Email = "jeff@gmail.com", Situacao = EnumSituacao.Andamento },
                new Person { Nome = "Carlos Slim", Email = "carlos@gmail.com", Situacao = EnumSituacao.Andamento },
                new Person { Nome = "Warren Buffet", Email = "warren@gmail.com", Situacao = EnumSituacao.Atrasado },
                new Person { Nome = "Amancio Ortega", Email = "ortega@gmail.com", Situacao = EnumSituacao.Andamento },
                new Person { Nome = "Bill Gates", Email = "gates@gmail.com", Situacao = EnumSituacao.Andamento }
            };         
        }
    }
}