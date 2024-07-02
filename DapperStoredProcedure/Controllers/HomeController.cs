using Dapper;
using DapperStoredProcedure.Models;
using DapperStoredProcedure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DapperStoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly IDapperRepository _repository;
        public CrudController(IDapperRepository repository)
        {
            _repository = repository;
        }
        [HttpPost(nameof(Create))]
        public async Task<int> Create(Member data)
        {
            var dp_params = new DynamicParameters();
            dp_params.Add("Id", data.Id, DbType.Int32);
            dp_params.Add("Name", data.Name, DbType.String);
            dp_params.Add("Address", data.Address, DbType.String);
            dp_params.Add("Contact", data.Contact, DbType.String);
            dp_params.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_repository.Execute_sp<int>("[dbo].[sp_AddMember]"
                , dp_params,
                commandType: CommandType.StoredProcedure));
            return result;
        }
        [HttpGet(nameof(GetMembers))]
        public async Task<List<Member>> GetMembers()
        {
            var result = await Task.FromResult(_repository.GetAll<Member>($"Select * from [members]", null, commandType: CommandType.Text));
            return result;
        }
        [HttpPost(nameof(Update))]
        public async Task<int> Update(Member data)
        {
            var dp_params = new DynamicParameters();
            dp_params.Add("Id", data.Id, DbType.Int32);
            dp_params.Add("Name", data.Name, DbType.String);
            dp_params.Add("Address", data.Address, DbType.String);
            dp_params.Add("Contact", data.Contact, DbType.String);
            dp_params.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_repository.Execute_sp<int>("[dbo].[sp_UpdateMember]"
                , dp_params,
                commandType: CommandType.StoredProcedure));
            return result;
        }
        [HttpDelete(nameof(Delete))]
        public async Task<int> Delete(int Id)
        {
            var dp_params = new DynamicParameters();
            dp_params.Add("Id", Id, DbType.Int32);
            dp_params.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = await Task.FromResult(_repository.Execute_sp<int>("[dbo].[sp_DeleteMember]"
                , dp_params,
                commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
