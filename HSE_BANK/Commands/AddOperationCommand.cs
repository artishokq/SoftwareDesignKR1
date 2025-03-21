using HSE_BANK.Domain;
using HSE_BANK.Facades;

namespace HSE_BANK.Commands;

public class AddOperationCommand : ICommand
{
    private readonly OperationFacade _operationFacade;
    private readonly OperationType _type;
    private readonly Guid _bankAccountId;
    private readonly decimal _amount;
    private readonly DateTime _date;
    private readonly Guid _categoryId;
    private readonly string _description;

    public AddOperationCommand(OperationFacade operationFacade, OperationType type, Guid bankAccountId, decimal amount,
        DateTime date, Guid categoryId, string description = null)
    {
        _operationFacade = operationFacade;
        _type = type;
        _bankAccountId = bankAccountId;
        _amount = amount;
        _date = date;
        _categoryId = categoryId;
        _description = description;
    }

    public void Execute()
    {
        _operationFacade.CreateOperation(_type, _bankAccountId, _amount, _date, _categoryId, _description);
    }
}