namespace MiniBudget.Shared.Model;

public record Category(int Id, int AccountId, string Name, decimal Balance);
