# Part 01 — answers

## ShippingCostCalculator

* What was the problem?

  * The calculator used a switch statement to select a shipping carrier, so adding a new carrier required modifying the existing calculator.
* What did you change?

  * Introduced IShippingCarrier and separate carrier classes. The calculator now uses injected carrier implementations.

## OrderProcessor

* What was the problem?

  * OrderProcessor directly instantiated SqlOrderRepository and SmtpEmailSender, creating hard-wired dependencies.
* What did you change?

  * Introduced IOrderRepository and INotificationSender abstractions and injected them through the constructor.

## Notifications

* What was the problem?

  * Inheritance combined notification channels, urgency, and scheduling, creating a growing hierarchy of classes.
* What did you change?

  * Replaced the inheritance hierarchy with INotificationChannel and a Notification class that composes a channel with urgency and scheduling options.
  * ## \## Proof
  * ## \- New carrier files: AramexCarrier.cs, FedExCarrier.cs, DhlCarrier.cs, BostaCarrier.cs.
  * ## \- New notification channel files: EmailChannel and SmsChannel in Notifications.cs, and WhatsAppChannel.cs.
  * ## \- Existing classes left unchanged? No. ShippingCostCalculator, OrderProcessor, Notifications, and Program were refactored during the initial implementation. After the refactoring, adding Bosta does not require modifying ShippingCostCalculator, and adding WhatsAppChannel does not require modifying Notification or the existing channel classes. Program.cs was updated to register and demonstrate the new implementations.

