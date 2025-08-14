# ประเภทของ Services

## Singleton
สร้างเพียงหนึ่ง instance ต่อ container (ตลอดอายุของแอปหรือ DI scope ใหญ่สุด)

ทุก request, ทุก class ที่ inject จะได้ object เดียวกัน

เหมาะกับ service ที่ stateless และต้องการ cache หรือ shared resource

ระวัง state ที่เปลี่ยนเพราะจะกระทบทุก request


## Scoped
สร้างหนึ่ง instance ต่อ scope (ใน Web API scope = หนึ่ง HTTP request)

ทุก dependency ใน request เดียวกันได้ instance เดียวกัน

Request อื่นจะได้ instance ใหม่

เหมาะกับ service ที่ต้องเก็บข้อมูลหรือ state เฉพาะ request


## Transient
สร้าง instance ใหม่ทุกครั้งที่ resolve

แม้ใน request เดียวกัน ถ้า resolve หลายครั้งก็ได้ object คนละตัว

เหมาะกับ service ที่เบามากและ stateless

ใช้ได้ปลอดภัยกับ multi-thread ถ้าไม่มี shared state

## การทำงานแบบ Stateful หรือ Stateless 

### Stateless
ไม่มีข้อมูลในตัวเอง, ทำงานเหมือนกันทุกครั้งที่เรียก

ใช้กับ Singleton, Scoped, Transient ได้หมด ปลอดภัยต่อ multi-thread


### Stateful
เก็บข้อมูลในตัวเอง, ผลลัพธ์ขึ้นกับการใช้งานครั้งก่อน

ใช้กับ Scoped ได้ปลอดภัย (state อยู่ใน request เดียว)

ใช้กับ Transient ได้ถ้าต้องการ state ใหม่ทุกครั้ง

ไม่ควรใช้กับ Singleton เว้นแต่จัดการ concurrency เอง

```c#
public interface ICounter
{
    int Increment();
}

// Stateless
public class StatelessCounter : ICounter
{
    public int Increment() => 1; // ไม่เก็บ state
}

// Stateful
public class StatefulCounter : ICounter
{
    private int _count = 0; // เก็บ state
    public int Increment() => ++_count;
}
```
