# Контрольная работа №1 по КПО

## 1. Общая идея решения

Проект реализует модуль "Учет финансов". Реализуемый функционал:
- Управление банковскими счетами (создание, редактирование, удаление, просмотр).
- Работа с категориями (создание, редактирование, удаление, просмотр).
- Выполнение операций (доходы и расходы) с автоматическим обновлением баланса счета.
- Произведение аналитики: подсчитывание разницф между доходами и расходами за выбранный период.
- Импортирование и экспортирование данных (банковские счета, категории и операции) в различных форматах (JSON, CSV, YAML).
- Измерение времени выполнения пользовательских сценариев с использованием паттерна Декоратор для команд.
- Пользовательский интерфейс реализован в виде консольного меню.
<img width="368" alt="do" src="https://github.com/user-attachments/assets/896de467-f0cb-4a22-921b-f77924da8446" />

Также приведены тестовые фалйы, их можно найти в папке test_files
## 2. SOLID и GRASP

### SOLID:
- **Single Responsibility:**  
  - Доменные классы (`BankAccount`, `Category`, `Operation`) отвечают только за бизнес-логику.
  - Фасады (`AnalyticsFacade`, `BankAccountFacade`, `CategoryFacade`, `OperationFacade`) объединяют CRUD-операции и упрощают взаимодействие с доменной моделью.
  - Импортеры/экспортеры (наследники `GenericDataImporter` и реализации `GenericDataExporter`) занимаются обработкой данных.

- **Open/Closed:**  
  - Использование шаблонного метода в классе `GenericDataImporter` позволяет добавлять новые форматы импорта без изменения базового алгоритма.
  
- **Liskov Substitution:**  
  - Интерфейсы, такие как `IRepository<T>` обеспечивают возможность замены реализаций без нарушения логики приложения.
  
- **Interface Segregation:**  
  - Разделение обязанностей реализовано через отдельные интерфейсы для репозиториев и экспортеров.
  
- **Dependency Inversion:**  
  - В проекте используется DI-контейнер Microsoft.Extensions.DependencyInjection для внедрения зависимостей.

### GRASP:
- **High Cohesion:**  
  - Каждый модуль имеет чётко определённую ответственность.
  
- **Low Coupling:**  
  - Модули общаются через абстракции, что снижает зависимость между компонентами.

## 3. GoF

- **Facade:**  
  - `BankAccountFacade`, `CategoryFacade`, `OperationFacade` и `AnalyticsFacade` объединяют наборы операций над соответствующими сущностями, предоставляя упрощённый интерфейс для взаимодействия с доменной моделью.
  
- **Command и Decorator:**  
  - Паттерн Command реализован через интерфейс `ICommand` и класс `AddOperationCommand`, который инкапсулирует логику добавления операции.
  - Паттерн Decorator реализован в виде `CommandTimerDecorator`, который измеряет время выполнения команд, не изменяя их логику.
  
- **Шаблонный метод:**  
  - Абстрактный класс `GenericDataImporter` задаёт общий алгоритм импорта данных, а его наследники реализуют специфичный для формата парсинг.
  
- **Visitor:**  
  - Интерфейс экспорта, например `GenericDataExporter` и его реализации для каждого формата, используются для экспорта данных в разные форматы, позволяя отделить логику экспорта от структуры данных.
  
- **Factory:**  
  - Класс `DomainFactory` централизует создание доменных объектов с необходимой валидацией, что помогает избежать дублирования кода.

## 4. Инструкция по запуску

1. Клонировать репозиторий проекта.
2. Собрать решение:
    
   dotnet build HSE_BANK/HSE_BANK.csproj
   
   dotnet build Tests/Tests.csproj
4. Запустить консольное приложение: dotnet run --project HSE_BANK/HSE_BANK.csproj
5. Запустить тесты: dotnet test Tests/Tests.csproj

## 5. Тестирование

Проект покрыт тестами (xUnit) более чем на 65% кода. 
<img width="684" alt="tests" src="https://github.com/user-attachments/assets/863a064d-a828-4ff0-8a76-90f4f55ef9b3" />
<img width="439" alt="coverage" src="https://github.com/user-attachments/assets/231fe54f-f13e-47c1-b33a-740b5a4067c8" />
