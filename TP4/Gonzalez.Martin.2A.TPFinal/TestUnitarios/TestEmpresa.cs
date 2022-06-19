using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace TestUnitarios
{
    [TestClass]
    public class TestEmpresa
    {
        /// <summary>
        /// Testea si la lista de clientes no es nula al instanciar una Empresa
        /// </summary>
        [TestMethod]
        public void TestListaInstanciada()
        {
            Empresa empresa = new Empresa();
            Assert.IsNotNull(empresa.Clientes);
        }

        /// <summary>
        /// Testea si se produce una excepcion al agregar un cliente a la empresa con el mismo dni de otro
        /// </summary>
        [TestMethod]
        public void TestMismoNumeroDeAfiliado()
        {
            Empresa empresa = new Empresa();
            Cliente clienteUno = new Cliente("Juan","Perez","Pastillas","4587");
            Cliente ClienteDos = new Cliente("Rocio", "Toledo", "Crema", "4587");
            empresa += clienteUno;
            try
            {
                empresa += ClienteDos;
                
            }
            catch (Exception )
            {
                //Assert.IsInstanceOfType(e, typeof(NrmAfiliadoRepetidoException));
                throw new NrmAfiliadoRepetidoException("Ya existe un cliente con el mismo numero de afiliado");
            }
        }
    }
}
