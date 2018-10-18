using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace KorchekTechnologiesCodingExercise.Data
{
    public class ClassManipulation : BaseData
    {
        public List<string> ObterDados(int CodSampleID)
        {
            #region Query

            string query = @"SELECT * 
                             FROM [TABLE]
                             WHERE [TABLE].Id = @CodSampleID";

            #endregion

            try
            {
                var accessor = database.CreateSqlStringAccessor<string>(query, new ParameterMappers.ParameterMapperSample(),
                                                                               new ResultSetMappers.ResultSetSample());
                return accessor.Execute(CodSampleID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
