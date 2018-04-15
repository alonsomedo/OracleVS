using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class MedicamentoLN
    {
        #region "PATRON SINGLETON"
        private static MedicamentoLN ObjMedicamento = null;
        private MedicamentoLN() { }
        public static MedicamentoLN GetInstance()
        {
            if (ObjMedicamento == null)
            {
                ObjMedicamento = new MedicamentoLN();
            }
            return ObjMedicamento;
        }

        #endregion

        public List<Medicamento> ListarMedicamento()
        {
            try
            {
                return MedicamentoDAO.GetInstance().ListarMedicamento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarMedicamento(Medicamento objMedicamento)
        {
            try
            {
                return MedicamentoDAO.GetInstance().RegistrarMedicamento(objMedicamento);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<TipoMedicamento> ListarTipoMedicamento()
        {
            try
            {
                return MedicamentoDAO.GetInstance().ListarTipoMedicamento();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
