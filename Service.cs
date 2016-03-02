using Datalus.Data;
using Datalus.Web.Domain;
using Datalus.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datalus.Web.Services
{
    public class EmploymentsService : BaseService
    {
        public static int AddEmployments(EmploymentsAddRequest Employments)
        {
            int id = 0;
            string UserProfileId = UserService.GetCurrentUserId();

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Employments_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@StartDate", Employments.StartDate);
                    paramCollection.AddWithValue("@EndDate", Employments.EndDate);
                    paramCollection.AddWithValue("@CompanyName", Employments.CompanyName);
                    paramCollection.AddWithValue("@JobTitle", Employments.JobTitle);
                    paramCollection.AddWithValue("@Department", Employments.Department);
                    paramCollection.AddWithValue("@Location", Employments.Location);
                    paramCollection.AddWithValue("@SummaryOfJob", Employments.SummaryOfJob);
                    
                    paramCollection.AddWithValue("@UserProfileId", Employments.UserProfileId);

                    SqlParameter newIdParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    newIdParameter.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(newIdParameter);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@id"].Value.ToString(), out id);
                }
                );
            return id;
        }

        public static void UpdateEmployments(EmploymentsUpdateRequest Employments)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Employments_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@StartDate", Employments.StartDate);
                    paramCollection.AddWithValue("@EndDate", Employments.EndDate);
                    paramCollection.AddWithValue("@CompanyName", Employments.CompanyName);
                    paramCollection.AddWithValue("@JobTitle", Employments.JobTitle);
                    paramCollection.AddWithValue("@Department", Employments.Department);
                    paramCollection.AddWithValue("@Location", Employments.Location);
                    paramCollection.AddWithValue("@SummaryOfJob", Employments.SummaryOfJob);
                    //paramCollection.AddWithValue("@Id", Employments.Id);

                }, returnParameters: null
                );
        }

        public static Employments GetEducation(int id)
        {
            Employments model = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Employments_SelectById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@id", id);
               }, map: delegate (IDataReader reader, short set)
               {
                   model = MapEmployments(reader);
               }
                   );
            return model;
        }

        public static List<Employments> GetAllEmployments()
        {
            List<Employments> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Employments_SelectAll"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Employments education = MapEmployments(reader);

                   if (list == null)
                   {
                       list = new List<Employments>();
                   }

                   list.Add(education);
               }
               );
            return list;
        }

        public static void DeleteEmployments(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Employments_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, returnParameters: null);

        }

        private static Employments MapEmployments(IDataReader reader)
        {
            Employments model = new Employments();
            int startingIndex = 0;

            model.Id = reader.GetSafeInt32(startingIndex++);
            model.StartDate = reader.GetDateTime(startingIndex++);
            model.EndDate = reader.GetDateTime(startingIndex++);
            model.CompanyName = reader.GetSafeString(startingIndex++);
            model.JobTitle = reader.GetSafeString(startingIndex++);
            model.Department = reader.GetSafeString(startingIndex++);
            model.Location = reader.GetSafeString(startingIndex++);
            model.SummaryOfJob = reader.GetSafeString(startingIndex++);

            return model;
        }



    }
}
