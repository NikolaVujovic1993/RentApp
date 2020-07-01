using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.BrandCommands;
using Application.DataTransfer.RequestDTO;
using Application.DataTransfer.ResponseDTO;
using Application.Exceptions;
using DomainModels;
using Domain;
using Application.Interfaces;

namespace Implementation.BrandCommands
{
    public class EFInsertBrandCommand : BaseEFCommand, IInsertBrandCommand
    {
        readonly IEmailSender _emailSender;
        public EFInsertBrandCommand(AIContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }

        public Brand Execute(BrandRequestDTO request)
        {
            var brand = new Brand();
            var existingBrand = AiContext.Brands.Where(x => x.Name == request.Name).Where(x => x.IsDeleted == 0).FirstOrDefault();
            if (existingBrand != null)
                throw new EntityExistsException("Brand");
            brand.Name = request.Name;
            AiContext.Brands.Add(brand);
            AiContext.SaveChanges();
            _emailSender.Body = "Your rent has ended, thank you for using our service!";
            _emailSender.Subject = "Rent reservation";
            _emailSender.ToEmail = "nikola.vujovic.160.15@ict.edu.rs";
            _emailSender.Send();
            return brand;
            //return new BrandResponseDTO
            //{
            //    Id = brand.Id,
            //    Name = brand.Name
            //};

        }
    }
}
