# CSharp-Order-Event-System

## Real-Time Order Notification System

This project is a console-based Order Processing System using C# Delegates and Events.

### Features

* Process customer orders
* Send Email notification
* Send SMS notification
* Log order details
* Use Delegates and Events
* Multicast Delegate implementation
* Publisher-Subscriber Model

### Classes Used

* Order.cs
* OrderProcessor.cs
* EmailService.cs
* SMSService.cs
* LoggerService.cs
* Program.cs

### Delegate Used

```csharp id="qfsv7t"
public delegate void OrderPlacedHandler(Order order);
```

### Event Used

```csharp id="jlwm0o"
public event OrderPlacedHandler OnOrderPlaced;
```

### Expected Output

```text id="m0fz3d"
Order Placed: 101
Email sent to customer
SMS sent to customer
Order logged successfully
```

