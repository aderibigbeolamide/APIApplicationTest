using System.Linq;
using APIApplication.DTOs;
using APIApplication.DTOs.RequestModel;
using APIApplication.DTOs.ResponseModel;
using APIApplication.Interfaces.Repositories;
using APIApplication.Interfaces.Services;
using APIApplication.Model;
using CMSApp.Interfaces.Repositories;

namespace APIApplication.Implementations.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IDocumentRepository _documentRepository;
        public FormService(IFormRepository formRepository, IDocumentRepository documentRepository)
        {
            _formRepository = formRepository;
            _documentRepository = documentRepository;
        }

        public async Task<BaseResponseModel> CreateForm(CreateFormRequestModel model)
        {
            var check = await _formRepository.Get(x => x.Email == model.Email);
            if (check != null)
            {
                return new BaseResponseModel
                {
                    Message = "A Form with this email already Exist",
                    Success = false,
                };
            }
            var form = new Form
            {
                Image = model.Image,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Nationality = model.Nationality,
                CurrentResident = model.CurrentResident,
                IDNumber = model.IDNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Education = model.Education,
                Experience = model.Experience,
                Resume = model.Resume,
            };
            await _formRepository.Register(form);
            return new BaseResponseModel
            {
                Message = "A Form Registered Successfully",
                Success = false,
            };
        }

        public async Task<FormsResponseModel> GetAll()
        {
            var checkForm = await _formRepository.GetAll();
            var form = checkForm.Where(x => x.IsDeleted == false).Select(x => new FormDTO
            {
                Image = x.Image,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Nationality = x.Nationality,
                CurrentResident = x.CurrentResident,
                IDNumber = x.IDNumber,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                Education = x.Education,
                Experience = x.Experience,
                Resume = x.Resume,
            }).ToList();
            if (checkForm == null)
            {
                return new FormsResponseModel
                {
                    Message = "Form not Fund",
                    Success = true
                };
            }
            return new FormsResponseModel
            {
                Success = true,
                Data = form,
                Message = "List of Forms",
            };
        }

        public async Task<FormResponseModel> GetById(int id)
        {
            var form = await _formRepository.GetForm(id);
            if (form == null)
            {
                return new FormResponseModel
                {
                    Message = "Form not Available",
                    Success = true
                };
            }
            var formDTO = new FormDTO
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                CurrentResident = form.CurrentResident,
                DateOfBirth = form.DateOfBirth,
                Education = form.Education,
                Experience = form.Experience,
                Gender = form.Gender,
                IDNumber = form.IDNumber,
                Image = form.Image,
                Nationality = form.Nationality,
                PhoneNumber = form.PhoneNumber,
                Resume = form.Resume,   
            };
            return new FormResponseModel
            {
                Message = "Form fund",
                Success = true,
            };
        }

        public async Task<BaseResponseModel> UpdateForm(UpdateFormRequestModel model, int id)
        {
            var form = await _formRepository.Get(x => x.Id == id);
            if (form == null)
            {
                return new BaseResponseModel
                {
                    Message = "form not found",
                    Success = false
                };
            }
            form.FirstName = model.FirstName;
            form.LastName = model.LastName;
            form.Email = model.Email;
            form.Gender = model.Gender;
            form.Experience = model.Experience;
            form.Image = model.Image;
            form.IDNumber = model.IDNumber;
            form.Education = model.Education;
            form.CurrentResident = model.CurrentResident;
            form.Nationality = model.Nationality;
            form.DateOfBirth = model.DateOfBirth;
            form.PhoneNumber = model.PhoneNumber;
            form.Resume = model.Resume;
            await _formRepository.Update(form);
            return new BaseResponseModel
            {
                Message = "form Updated Successfully",
                Success = false
            };
        }
    }
}