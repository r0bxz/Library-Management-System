using LibraryMS.Borrowers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;


namespace LibraryMS.Managers
{
    public class BorrowerManager : DomainService
    {
        private readonly IRepository<Borrower, int> _borrowerRepository;

        public BorrowerManager(IRepository<Borrower, int> borrowerRepository)
        {
            _borrowerRepository = borrowerRepository;
        }

        public async Task<Borrower> CreateAsync(string fullName, string email, string phoneNumber)
        {
            

            var borrower = new Borrower
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            return await _borrowerRepository.InsertAsync(borrower);
        }

        public async Task<Borrower> UpdateAsync(int id, string fullName, string email, string phoneNumber)
        {
            
            var borrower = await _borrowerRepository.GetAsync(id);
            borrower.FullName = fullName;
            borrower.Email = email;
            borrower.PhoneNumber = phoneNumber;

            return await _borrowerRepository.UpdateAsync(borrower);
        }

        public async Task DeleteAsync(int id)
        {
            var borrower = await _borrowerRepository.GetAsync(id);
            await _borrowerRepository.DeleteAsync(borrower);
        }

        public async Task<Borrower> GetAsync(int id)
        {
            return await _borrowerRepository.GetAsync(id);
        }

        public async Task<List<Borrower>> GetAllAsync()
        {
            return await _borrowerRepository.GetListAsync();
        }

       
    }
}