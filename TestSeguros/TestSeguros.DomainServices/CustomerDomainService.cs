using System;
using System.Collections.Generic;
using System.Text;
using TestSeguros.Data;
using TestSeguros.Domain.Abstraction;
using TestSeguros.Repositories;
using TestSeguros.Repositories.Abstraction;

namespace TestSeguros.DomainServices
{
    public class CustomerDomainService : ICustomerDomainService
    {
        ITSegClientesRepository CustomerRepository { get; set; }

        public CustomerDomainService(ITSegClientesRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public CustomerDomainService()
        {
            CustomerRepository = new TSegClientesRepository();
        }

        public TSeg_Clientes CreateCustomer(TSeg_Clientes customer)
        {
            return CustomerRepository.CreateTSegCliente(customer);
        }

        public List<TSeg_Clientes> ReadCustomers()
        {
            return CustomerRepository.ReadTSegClientes();
        }

        public long DeleteCustomer(TSeg_Clientes customer)
        {
            CustomerRepository.DeleteTSegCliente(customer);
            return customer.id;
        }

        public TSeg_Clientes ReadCustomerById(long id)
        {
            return CustomerRepository.ReadTSegClienteById(id);
        }
    }
}
