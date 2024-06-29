# ProjektBackend - Wypożyczalnia Samochodów API

ProjektBackend to aplikacja API do zarządzania wypożyczalnią samochodów, zbudowana w architekturze Onion Architecture przy użyciu ASP.NET Core. Aplikacja korzysta z Identity, bazy danych SQL oraz JWT (JSON Web Token) do uwierzytelniania.

## Struktura Projektu

### Warstwa API
Zawiera kontrolery do obsługi żądań HTTP.

#### Kontrolery:

**AdminController**
- Tworzenie użytkownika z rolą Administratora.

**AuthorizationController**
- Rejestracja nowych użytkowników.
- Logowanie użytkowników i generowanie tokenów JWT.

**CarController**
- Pobieranie wszystkich samochodów.
- Pobieranie szczegółów samochodu.
- Tworzenie nowych samochodów (tylko Administrator).
- Edytowanie samochodów (tylko Administrator).
- Usuwanie samochodów.

**CategoryController**
- Pobieranie wszystkich kategorii samochodów.
- Pobieranie szczegółów kategorii.

**ClientController**
- Pobieranie wszystkich klientów (Administrator, Użytkownik).
- Pobieranie szczegółów klienta (Administrator, Użytkownik).
- Tworzenie nowych klientów (Administrator).

**OrderController**
- Pobieranie wszystkich zamówień (Administrator, Użytkownik).
- Pobieranie szczegółów zamówienia (Administrator, Użytkownik).
- Tworzenie nowych zamówień (Administrator).

### Warstwa Aplikacyjna
Zawiera serwisy do obsługi logiki biznesowej.

#### Serwisy:

**CarService**
- Obsługuje operacje związane z samochodami.

**CategoryService**
- Obsługuje operacje związane z kategoriami.

**ClientService**
- Obsługuje operacje związane z klientami.

**OrderService**
- Obsługuje operacje związane z zamówieniami.

### Warstwa Domeny
Zawiera encje oraz interfejsy.

#### Encje:

**Cars**
- Id samochodu, marka, model, kategoria, powiązane zamówienia.

**Categories**
- Id kategorii, nazwa kategorii, powiązane samochody.

**Clients**
- Id klienta, imię, nazwisko, email, powiązane zamówienia.

**Orders**
- Id zamówienia, data zamówienia, id użytkownika, id klienta, id samochodu, daty odbioru i zwrotu.

  Encje(Entites) posiadają 4 encje:
- Categories
- Cars
- Clients
- Orders
Oraz 7 związków:
- Categories - Cars: Jeden do wielu
- Cars - Categories: Wiele do jednego
- Cars - Orders: Jeden do wielu
- Clients - Orders: Jeden do wielu
- Orders - Users: Wiele do jednego
- Orders - Clients: Wiele do jednego
- Orders - Cars: Wiele do jednego

### Warstwa Infrastruktury
Zawiera implementacje repozytoriów oraz konfigurację bazy danych.

#### Repozytoria:

**CarRepository**
- Implementacja operacji CRUD dla samochodów.

**CategoryRepository**
- Implementacja operacji CRUD dla kategorii.

**ClientRepository**
- Implementacja operacji CRUD dla klientów.

**OrderRepository**
- Implementacja operacji CRUD dla zamówień.

#### ApplicationDbContext
Konfiguracja bazy danych i relacji między encjami.

### Modele:
Zawiera modele wykorzystywane w aplikacji.

**ApplicationUser**
- Rozszerza klasę IdentityUser o dodatkowe pola: FirstName, LastName.

**RegisterModel**
- Model rejestracji użytkownika.

**LoginModel**
- Model logowania użytkownika.

## Instalacja

1. Sklonuj repozytorium:
    ```bash
    git clone https://github.com/your-repo/ProjektBackend.git
    ```

2. Przejdź do katalogu projektu:
    ```bash
    cd ProjektBackend
    ```

3. Zainstaluj zależności:
    ```bash
    dotnet restore
    ```

4. Skonfiguruj bazę danych w pliku `appsettings.json`.

5. Uruchom migracje:
    ```bash
    dotnet ef database update
    ```

6. Uruchom aplikację:
    ```bash
    dotnet run
    ```

## Użycie

### Rejestracja
- Endpoint: `POST /Authorization/register`
- Body:
  ```json
  {
      "UserName": "string",
      "Email": "string",
      "Password": "string",
      "FirstName": "string",
      "LastName": "string"
  }
`

  ### Logowanie
- Endpoint: POST /Authorization/login
- Body:
  ```json
  {
      "Email": "string",
      "Password": "string"
  }


### Tworzenie nowego samochodu
- Endpoint: Endpoint: POST /Car
- Header: Authorization: Bearer {token}
- Body:
  ```json
  {
      "Brand": "string",
      "Model": "string",
      "CategoryId": int
  }
  ```

   ### Pobieranie wszystkich samochodów
- Endpoint: GET /Car
- Header: Authorization: Bearer {token}

### Testowanie

Aby przetestować API, można użyć narzędzi takich jak Postman lub Swagger UI dostępny pod adresem /swagger.

  

  
