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

Thread Safety + ข้อไม่ควรทำใน Service


---

1. Singleton

Stateless → ปลอดภัย

Stateful → ต้อง lock หรือทำ immutable

❌ ไม่ควรทำ

ห้ามแชร์ DbContext เพราะไม่ thread-safe และมี lifetime ควรเป็น Scoped

ห้ามเก็บ HttpContext หรือข้อมูล request ใดๆ เพราะจะรั่วข้าม request

ห้ามเก็บ connection เปิดค้างถ้าไม่จัดการปิดเอง




---

2. Scoped

Stateful → ปลอดภัยในขอบเขต request เดียว

Stateless → ใช้ได้

❌ ไม่ควรทำ

ห้ามเก็บ Scoped service ภายใน Singleton เพราะจะกลายเป็นการแชร์ object ของ request เดียวไปยัง request อื่น

ห้ามใช้ข้าม thread โดยไม่มีการ sync เพราะ async/parallel ใน request เดียวก็เจอ race condition ได้




---

3. Transient

Stateless / Stateful → ปลอดภัย เพราะสร้างใหม่ทุกครั้ง

❌ ไม่ควรทำ

หลีกเลี่ยงสร้าง object ที่หนักมาก เช่น HttpClient ในทุกครั้ง ควรใช้ Singleton + Factory/Pool แทน

อย่าใช้กับ resource ที่ต้อง reuse เพราะสิ้นเปลือง




---

ถ้าต้องสรุปเป็นสูตรจำง่าย:

Singleton → stateless, ห้ามมี request-specific data

Scoped → เก็บข้อมูลของ request ได้, ห้ามเก็บใน Singleton

Transient → ใช้กับของเบา, ไม่มีการแชร์ state
