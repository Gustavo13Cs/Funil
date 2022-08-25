using Funil.Models;
using INTELITRADER_Project.Models.Validacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace INTELUTRADE_Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Cadastro_DevePermitirCadastrar()
        {
            CANDIDATO c = new CANDIDATO();
            c.CANID = 1;
            c.CANNOME = "José";
            c.CANDIDATOVAGA = new List<CANDIDATOVAGA>();

            bool esperado = true;
            bool permiteCadastro = CandidatoValidations.CandidatoVagaValidarConcorrencia(c);

            Assert.AreEqual(esperado, permiteCadastro);
        }

        [TestMethod]
        public void Cadastro_NaoDevePermitirCadastrar()
        {
            CANDIDATO c = new CANDIDATO();
            c.CANID = 1;
            c.CANNOME = "José";
            c.CANDIDATOVAGA = new List<CANDIDATOVAGA>();

            CANDIDATOVAGA candidatoVaga = new CANDIDATOVAGA();
            candidatoVaga.CAVSTATUSCANDIDATURA = "Ativo";

            c.CANDIDATOVAGA.Add(candidatoVaga);

            bool esperado = false;
            bool permiteCadastro = CandidatoValidations.CandidatoVagaValidarConcorrencia(c);

            Assert.AreEqual(esperado, permiteCadastro);
        }
        [TestMethod]
        public void Cadastro_PossuiInscricaoFinalizada_DevePermitirCadastrar()
        {
            CANDIDATO c = new CANDIDATO();
            c.CANID = 1;
            c.CANNOME = "José";
            c.CANDIDATOVAGA = new List<CANDIDATOVAGA>();

            CANDIDATOVAGA candidatoVaga = new CANDIDATOVAGA();
            candidatoVaga.CAVSTATUSCANDIDATURA = "Finalizado";

            c.CANDIDATOVAGA.Add(candidatoVaga);

            bool esperado = true;
            bool permiteCadastro = CandidatoValidations.CandidatoVagaValidarConcorrencia(c);

            Assert.AreEqual(esperado, permiteCadastro);
        }
        [TestMethod]
        public void Cadastro_PossuiInscricaoCancelada_DevePermitirCadastrar()
        {
            CANDIDATO c = new CANDIDATO();
            c.CANID = 1;
            c.CANNOME = "José";
            c.CANDIDATOVAGA = new List<CANDIDATOVAGA>();

            CANDIDATOVAGA candidatoVaga = new CANDIDATOVAGA();
            candidatoVaga.CAVSTATUSCANDIDATURA = "Cancelada";

            c.CANDIDATOVAGA.Add(candidatoVaga);

            bool esperado = true;
            bool permiteCadastro = CandidatoValidations.CandidatoVagaValidarConcorrencia(c);

            Assert.AreEqual(esperado, permiteCadastro);
        }
    }
}
