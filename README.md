# SAP Business One Sales Commission Add-On

A custom-built **SAP Business One SDK Add-On** designed to automate complex sales commission calculations. The system replaces manual spreadsheets with a real-time engine that tracks performance against projections and collection milestones.

### 🚀 Business Logic & Complexity

The core of this project is a sophisticated calculation engine that evaluates two primary KPIs to determine agent payouts:

1.  **Total Sales Volume:** Commission based on gross sales targets.
2.  **Collection Efficiency (Aging Factor):** A specialized incentive that applies only if the payment is collected within **15 days post-maturity** of the final installment.
3.  **Dynamic Tiering:** Implements a conditional commission percentage (%) that fluctuates based on whether the salesperson achieves their **Projected Sales Target**.

### 🛠️ Technical Implementation

*   **SAP B1 SDK (UI/DI API):** Developed as a native Add-On, ensuring a seamless user experience within the SAP cockpit.
*   **Event-Driven Logic:** The engine monitors invoice status and incoming payments to trigger commission eligibility updates automatically.
*   **Advanced SQL Logic:** Complex stored procedures manage the heavy lifting of aging reports and multi-installment (last-letter) tracking.
*   **.NET & C#:** The business logic layer was built using C#, ensuring modularity and maintainability for different commission seasonal rules.

### 🏛️ Architecture Highlights

*   **Integrated UI:** Custom SAP forms and menus were created to allow managers to set sales projections directly within the ERP.
*   **Financial Integrity:** The system cross-references `OINV` (Invoices) and `ORCT` (Incoming Payments) tables to ensure that commissions are only calculated on confirmed liquidity, not just "paper" sales.
*   **Projection Engine:** A dedicated module to input and track monthly/quarterly targets per sales representative.

### 🛡️ Confidentiality & IP Notice

This repository contains the source code for architectural demonstration. To comply with professional ethics and NDAs:
*   Specific corporate financial formulas and private business rules have been abstracted.
*   Database connection strings and production server details are excluded.
*   The project is showcased here to demonstrate expertise in **ERP Extension, Financial Logic Automation, and SAP SDK Development**.

