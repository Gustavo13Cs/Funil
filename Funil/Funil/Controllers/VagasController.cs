using Funil.Models;
using INTELITRADER_Project.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Funil.Controllers
{
    public class VagasController : Controller
    {
        // GET: Vagas
        BDFunilEntities bd = new BDFunilEntities();
        public ActionResult Index()
        {
            return View(bd.VAGA.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Nome,string descricao,string atribuicao,decimal salario,string requisito,string cadastro)
        {
            VAGA novavaga = new VAGA();
            novavaga.VAINOME = Nome;
            novavaga.VAIDESCRICAO = descricao;
            novavaga.VAIATRIBUICAO = atribuicao;
            novavaga.VAISALARIO = Convert.ToInt32(salario);
            novavaga.VAIREQUISITO = requisito;
            novavaga.VAIDATACADASTRO = Convert.ToDateTime(cadastro);

            bd.VAGA.Add(novavaga);
            bd.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            VAGA localizarvagas = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(localizarvagas);
        }

        [HttpPost]
        public ActionResult Edit(int? id,string Nome, string descricao, string atribuicao, decimal salario, string requisito, string cadastro)
        {
            VAGA atualizarvaga = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            atualizarvaga.VAINOME = Nome;
            atualizarvaga.VAIDESCRICAO = descricao;
            atualizarvaga.VAIATRIBUICAO = atribuicao;
            atualizarvaga.VAISALARIO = Convert.ToInt32(salario);
            atualizarvaga.VAIREQUISITO = requisito;
            atualizarvaga.VAIDATACADASTRO = Convert.ToDateTime(cadastro);

            bd.Entry(atualizarvaga).State = EntityState.Modified;
            bd.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Excluir(int? id)
        {
            VAGA excluirvaga = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(excluirvaga);
        }


        [HttpPost]
        public ActionResult ExcluirConfirmar(int? id)
        {
            VAGA excluirvaga = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            bd.VAGA.Remove(excluirvaga);
            try
            {
                bd.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }

            return RedirectToAction("index");
        }

        public ActionResult Lista (int? id)
        {
            ViewBag.Listadecandidatos();
            return View();
        }

         public ActionResult Candidatos(int? id)
        {
             
            List<Vaga_Candidatos> lista = bd.Vaga_Candidato.Where(x => x.CodVaga == id).ToList();
            
            return View(lista);
        }

        public ActionResult Listar(int? id)
        {
            List<VAGA> Lista = bd.VAGA.ToList();
            return View(Lista);
        }

        public ActionResult Inscricao(int? id)
        {
            var usuarioLogado = bd.CANDIDATO.FirstOrDefault(x => x.CANID == 4);

            if (CandidatoValidations.CandidatoVagaValidarConcorrencia(usuarioLogado))
            {
                var vaga = bd.VAGA.Where(x => x.VAIID == id).FirstOrDefault();

                CANDIDATOVAGA novaInscricao = new CANDIDATOVAGA();
                novaInscricao.CANID = usuarioLogado.CANID;
                novaInscricao.VAIID = vaga.VAIID;
                novaInscricao.CAVDATACADASTRO = DateTime.Now;
                novaInscricao.CAVSTATUSCANDIDATURA = "Ativo";

                bd.CANDIDATOVAGA.Add(novaInscricao);
                bd.SaveChanges();
            }
            else
            {
                MensagemError.textoErro = "Não é possível se cadastra nessa vaga, pois já há um cadastro ativo";
                return RedirectToAction("BdError", "Home");
            }

            return View();
        }



    }
}