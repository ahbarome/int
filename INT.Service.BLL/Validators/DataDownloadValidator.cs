using System;
using INT.Service.BLL.Interfaces;
using INT.Service.DTO.Requests;
using System.Text;

namespace INT.Service.BLL.Validators
{
    public class DataDownloadValidator : IValidator<DataDownloadRequest>
    {
        public void Validate(DataDownloadRequest request)
        {
            var validationResult = new StringBuilder();

            if (string.IsNullOrWhiteSpace(request.FromIpAddress))
            {
                validationResult.AppendLine("El campo [FromIpAddress] es requerido");
            }

            request.ToDataBases.ForEach(toDataBase =>
            {
                if (string.IsNullOrWhiteSpace(toDataBase))
                {
                    validationResult.AppendLine("El campo [ToDataBase] es requerido");
                }
            });

            if (validationResult.Length > 0)
            {
                throw new Exception(validationResult.ToString());
            }
        }
    }
}
