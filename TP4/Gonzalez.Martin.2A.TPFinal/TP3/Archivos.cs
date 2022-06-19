using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Entidades;
using System.Xml;

namespace Entidades
{
    public class Archivos
    {
        /// <summary>
        /// Método que permitirá guardar el elemento seleccionado en la listbox en txt en la ruta de archivo pasada por parámetro
        /// </summary>
        /// <param name="rutaArchivo"></param>
        /// <param name="elemento">lista a guardar</param>
        public void GuardarArchivo(string rutaArchivo, string elemento)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(rutaArchivo))
                {
                    using StreamWriter streamWriter = new StreamWriter(rutaArchivo);
                    streamWriter.Write(elemento);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Serializa los datos de la lista en formato XML para luego proceder a guardarlos.
        /// </summary>
        /// <param name="rutaArchivoXml"></param>
        /// <param name="lista"></param>
        public void GuardarArchivoXML(string rutaArchivoXml, List<Cliente> lista)
        {
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivoXml))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(lista.GetType());
                    xmlSerializer.Serialize(streamWriter, lista);
                }
                catch (Exception ex)
                {
                   throw new ArchivosException(ex);
                }
            }
        }

        /// <summary>
        /// Serializa los datos de la lista en formato XML para luego proceder a guardarlos.
        /// </summary>
        /// <param name="ruta"></param>
        public void LeerArchivoXML(string rutaArchivoXml, List<Cliente> lista)
        {
            using (StreamReader streamReader = new StreamReader(rutaArchivoXml))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(lista.GetType());
                    lista = xmlSerializer.Deserialize(streamReader) as List<Cliente>;
                }
                catch (Exception ex)
                {
                    throw new ArchivosException(ex);
                }
            }
        }


    }
}
