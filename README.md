# Production Control 1.0

A Windows desktop application for managing the production flow of precast construction materials. It centralizes product and raw-material records, production entries, material-consumption data, inventory visibility, and operational indicators in a local SQLite database.

This project was developed as a university extension project at Cruzeiro do Sul Virtual. It represents an applied study in desktop software architecture, relational data modeling, CRUD workflows, validation, and data visualization with C#.

## What the application does

- Registers, searches, edits, and deactivates finished products.
- Registers, searches, edits, and removes raw materials.
- Records production by product, date, and quantity.
- Associates each production entry with the raw materials consumed.
- Keeps a production log for historical analysis.
- Displays production totals and record counts on a dashboard.
- Shows the five most-produced products and most-used raw materials.
- Highlights products and raw materials with low stock.
- Filters dashboard data by the current month, the last 7 or 30 days, or a custom date range.
- Groups chart data by day, week, month, or year according to the selected period.

## Architecture

The application follows an MVP-inspired separation of responsibilities:

```text
WinForms Views
     |
Presenters / validation
     |
Repository interfaces and implementations
     |
SQLite database
```

- **Views** contain the Windows Forms screens and expose user-interface events.
- **Presenters** coordinate user actions, validation, and data binding.
- **Repositories** isolate the parameterized SQLite queries used by the CRUD workflows.
- **Models** represent products, raw materials, production entries, and dashboard data.

## Main screens

| Area | Responsibility |
| --- | --- |
| Dashboard | Production KPIs, date filters, trend chart, top-five charts, and low-stock lists |
| Products | Product catalog, category, pallet units, stock, search, and activation status |
| Raw materials | Raw-material catalog, stock, search, and maintenance |
| Production | Production entries and raw-material quantities associated with each entry |

## Data model

The included SQLite database contains five application tables:

- `produtos`: finished products, categories, pallet units, stock, and active status.
- `materia_prima`: raw materials and stock quantities.
- `producao`: production entries by product, date, and quantity.
- `producao_materiaprima`: relationship between production entries and consumed raw materials.
- `producao_log`: historical production records used by the dashboard.

The repository includes a small demonstration dataset with fictitious product and inventory information so the interface can be explored immediately.

## Technology stack

- C#
- .NET Framework 4.8
- Windows Forms
- System.Data.SQLite 1.0.119
- Windows Forms DataVisualization charts
- MVP-style architecture and repository pattern
- Data Annotations validation

## Running locally

### Requirements

- Windows
- Visual Studio 2019 or newer with the **.NET desktop development** workload
- .NET Framework 4.8 Developer Pack

### Steps

1. Clone the repository:

   ```powershell
   git clone https://github.com/ViniOcCode/Controle-de-Producao-1.0.git
   ```

2. Open `ControleProdForms.sln` in Visual Studio.
3. Restore the NuGet packages when prompted.
4. Set `ControleProdForms` as the startup project.
5. Run the project with `F5`.

The application reads the demonstration database from `bin/Files/database.db` when launched through Visual Studio.

## Project structure

```text
Models/       Domain and dashboard models plus repository contracts
Presenters/   UI coordination and model validation
View/         Windows Forms screens and view interfaces
_Repos/       SQLite repository implementations
bin/Files/    Demonstration database and interface assets
```

## Project scope

This is an academic portfolio project rather than a production-ready ERP. It was designed to exercise end-to-end desktop application development: translating an operational problem into screens, data relationships, business workflows, and visual indicators. The bundled database and relative file paths reflect the original classroom/demo environment.

<details>
<summary><strong>Português</strong></summary>

## Controle de Produção 1.0

Aplicativo desktop para Windows voltado ao controle da produção de materiais pré-moldados para construção. O sistema reúne cadastros de produtos e matérias-primas, lançamentos de produção, consumo de materiais, acompanhamento de estoque e indicadores operacionais em um banco SQLite local.

O projeto foi desenvolvido como atividade de extensão universitária na Cruzeiro do Sul Virtual e aplica conceitos de arquitetura de software desktop, modelagem relacional, CRUD, validação e visualização de dados com C#.

### Funcionalidades

- Cadastro, pesquisa, edição e desativação de produtos.
- Cadastro, pesquisa, edição e exclusão de matérias-primas.
- Registro da produção por produto, data e quantidade.
- Associação dos insumos consumidos em cada lançamento.
- Histórico de produção para análise.
- Dashboard com totais, evolução da produção, rankings e alertas de estoque baixo.
- Filtros pelo mês atual, últimos 7 ou 30 dias e intervalo personalizado.

### Como executar

1. Abra `ControleProdForms.sln` no Visual Studio 2019 ou superior.
2. Restaure os pacotes NuGet.
3. Confirme `ControleProdForms` como projeto de inicialização.
4. Execute com `F5`.

O projeto requer Windows, o workload **Desenvolvimento para desktop com .NET** e o .NET Framework 4.8 Developer Pack.

</details>
