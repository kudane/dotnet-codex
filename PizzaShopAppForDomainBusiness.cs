namespace PizzaShopDemo;

// --- 1. Domain Models & Result Pattern ---
public record Result<T>(T? Value, bool IsSuccess, string Error = "")
{
    public static Result<T> Success(T value) => new(value, true);
    public static Result<T> Failure(string error) => new(default, false, error);
}

public record PizzaOrderRequest(string Name, int Quantity);
public record OrderResponse(int OrderId, string Status, string? PickupChannel);

// --- 2. Abstractions (SOLID: Dependency Inversion) ---
public interface IInventoryService
{
    bool IsAvailable(string name, int quantity);
}

public interface IOrderRepository
{
    int SaveOrder(string name, int quantity);
}

public interface IPizzaChefService
{
    CookResult PreparePizza(int orderId);
}

public record CookResult(string PickupChannel, DateTime ReadyTime);

// --- 3. Use Case (The Storyteller / Orchestrator) ---
public interface IPlaceOrderUseCase
{
    Result<OrderResponse> Execute(PizzaOrderRequest request);
}

public class PlaceOrderUseCase(
    IInventoryService inventory,
    IOrderRepository repository,
    IPizzaChefService chef) : IPlaceOrderUseCase
{
    public Result<OrderResponse> Execute(PizzaOrderRequest request)
    {
        // ลำดับ 1: เช็คสต็อกก่อนเสมอ (ป้องกัน Record ขยะใน DB)
        if (!inventory.IsAvailable(request.Name, request.Quantity))
        {
            return Result<OrderResponse>.Failure("ขออภัย วัตถุดิบไม่เพียงพอสำหรับออเดอร์นี้");
        }

        // ลำดับ 2: เมื่อของมีจริง ค่อยสร้าง Order ในระบบ
        var orderId = repository.SaveOrder(request.Name, request.Quantity);

        // ลำดับ 3: ส่งต่อให้แผนกครัวทำอาหาร
        var cookInfo = chef.PreparePizza(orderId);

        var response = new OrderResponse(orderId, "กำลังจัดเตรียม", cookInfo.PickupChannel);
        return Result<OrderResponse>.Success(response);
    }
}

// --- 4. Endpoint (Framework Layer) ---
public class PizzaOrderEndpoint(IPlaceOrderUseCase useCase)
{
    public object Post(PizzaOrderRequest request)
    {
        var result = useCase.Execute(request);

        if (!result.IsSuccess)
        {
            return new { Status = 400, Message = result.Error };
        }

        return new { Status = 200, Data = result.Value };
    }
}
