namespace SystemSoftApi.Models;

public record LabWorkVariant
{
    public string? UaNameFirstTable { get; set; }
    public string? EnNameFirstTable { get; set; }
    public string? UaNameSecondTable { get; set; }
    public string? EnNameSecondTable { get; set; }
    public string? UaDescFirst { get; set; }
    public string? UaDescSecond { get; set; }
}

public static class VariantsVault
{
    public static string GetVariantText(int variant)
    {
        var year = DateTime.Today.Year;
        
        var forQuery = (variant + year) % 30;
        
        var currentVariant = variants[forQuery];
        
        var htmlContent = 
        $"""
        <html>
        <head>
        <meta charset="UTF-8">
        <title>Варіант {variant}</title>
        </head>
        <body> 

        <h1>Варіант {variant}</h1>
        <h2>Створення сутностей в проекті <code>{currentVariant.EnNameFirstTable}{currentVariant.EnNameSecondTable}Catalog.DB</code>:</h2>
        <ul>
          <li><strong>Сутність {currentVariant.UaNameFirstTable} <span>&#10132;</span> {currentVariant.EnNameFirstTable}</strong>.</li>
          <li><strong>Сутність {currentVariant.UaNameSecondTable} <span>&#10132;</span> {currentVariant.EnNameSecondTable}</strong>.</li>
        </ul>

        <h2>Визначення зв'язків між сутностями:</h2>
        <ul>
          <li><strong>Сутність {currentVariant.EnNameFirstTable} має зв'язок з сутністю {currentVariant.EnNameSecondTable}</strong> (зв'язок "один до багатьох"):
            <ul>
              <li>{currentVariant.UaDescFirst}</li>
              <li>{currentVariant.UaDescSecond}</li>
            </ul>
          </li>
        </ul>

        <h2>Обмеження та додаткові умови:</h2>
        <ol>
          <li><strong>Обидві сутності</strong> повинні мати:
            <ul>
              <li>обов'язкове поле для назви сутності <strong>Name</strong>, обмежене {140 + variant % 200 * 10 } символами.
                <ul>
                  <li>Використовуйте <code>HasMaxLength</code> або атрибут <code>MaxLength</code>.</li>
                </ul>
              </li>
            </ul>
          </li>
          <li><strong>Обидві сутності</strong> повинні мати:
            <ul>
              <li>два поля <code>DateTime</code> для відображення часу створення <strong>CreatedAt</strong> та модифікації <strong>ModifiedAt</strong>.
                <ul>
                  <li>Реалізуйте за допомогою Fluent API або властивостей Data Annotation.</li>
                </ul>
              </li>
            </ul>
          </li>
        </ol>

        <h2>Створення додатка <code>{currentVariant.EnNameFirstTable}{currentVariant.EnNameSecondTable}Catalog ASP.NET Core</code>:</h2>
        <ol>
          <li><strong>Створити веб-додатка ASP.NET Core</strong>:
            <ul>
              <li>ASP.NET Core зі стандартними налаштуваннями.</li>
            </ul>
          </li>
          <li><strong>Впровадження патерну <code>Repository</code></strong>:
            <ul>
              <li>Створіть клас <strong><code>{currentVariant.EnNameFirstTable}{currentVariant.EnNameSecondTable}Repository</code></strong>.</li>
              <li>Цей клас повинен містити методи для:
                <ul>
                  <li>додавання</li>
                  <li>редагування</li>
                  <li>видалення</li>
                  <li>сутностей <strong>{currentVariant.UaNameSecondTable}</strong> та <strong>{currentVariant.UaNameFirstTable}</strong>.</li>
                </ul>
              </li>
            </ul>
          </li>
          <li><strong>Сторінка відображення каталогу {currentVariant.EnNameFirstTable}</strong>:
            <ul>
              <li><strong>Додавання</strong> сутностей <strong>{currentVariant.UaNameSecondTable}</strong> та <strong>{currentVariant.UaNameFirstTable}</strong>:
                <ul>
                  <li>Валідація значень: заборонити пусті значення.</li>
                  <li>Кнопка: Add - виконати додавання.</li>
                </ul>
              </li>
              <li><strong>Редагування</strong> сутностей <strong>{currentVariant.UaNameSecondTable}</strong> та <strong>{currentVariant.UaNameFirstTable}</strong>:
                <ul>
                  <li>Валідація: аналогічно до додавання.</li>
                  <li>Кнопки:
                    <ul>
                      <li>Save - зберегти.</li>
                      <li>Cancel - відмінити редагування.</li>
                      <li>Delete - видалити рядок.</li>
                    </ul>
                  </li>
                </ul>
              </li>
              <li><strong>Відображення</strong> сутностей <strong>{currentVariant.UaNameSecondTable}</strong> та <strong>{currentVariant.UaNameFirstTable}</strong>:
                <ul>
                  <li>При завантаженні сторінки, відобразити всі сутності з <strong><code>{currentVariant.EnNameFirstTable}{currentVariant.EnNameSecondTable}Repository</code></strong>. окремо для кожно ї з сутностей <strong>{currentVariant.UaNameSecondTable}</strong> та <strong>{currentVariant.UaNameFirstTable}</li>
                </ul>
              </li>
              <li><strong>Спадне меню</strong> при редагуванні <strong>{currentVariant.UaNameFirstTable}</strong>:
                <ul>
                  <li>При редагуванні, можливість вибрати <strong>{currentVariant.UaNameSecondTable}</strong> з таблиці <strong>{currentVariant.EnNameSecondTable}</strong>.</li>
                </ul>
              </li>
            </ul>
          </li>
        </ol> 
        </body>
        </html>
        """;

        return htmlContent;
    }
    
    
    public static LabWorkVariant[] variants = new[]
    {
        new LabWorkVariant()
        {
            EnNameFirstTable = "Book",
            EnNameSecondTable = "Genre",
            UaNameFirstTable = "Книга",
            UaNameSecondTable = "Жанр",
            UaDescFirst = "Одна книга належить до одного жанру.",
            UaDescSecond = "Один жанр може охоплювати багато книг."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Student",
            EnNameSecondTable = "Course",
            UaNameFirstTable = "Студент",
            UaNameSecondTable = "Курс",
            UaDescFirst = "Один студент записаний на один курс.",
            UaDescSecond = "На одному курсі може бути багато студентів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Car",
            EnNameSecondTable = "Manufacturer",
            UaNameFirstTable = "Автомобіль",
            UaNameSecondTable = "Виробник",
            UaDescFirst = "Один автомобіль виробляється одним виробником.",
            UaDescSecond = "Один виробник може виробляти багато автомобілів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Artist",
            EnNameSecondTable = "Album",
            UaNameFirstTable = "Артист",
            UaNameSecondTable = "Альбом",
            UaDescFirst = "Один артист випускає один альбом.",
            UaDescSecond = "Один альбом можуть складати багато артистів"
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Employee",
            EnNameSecondTable = "Department",
            UaNameFirstTable = "Співробітник",
            UaNameSecondTable = "Відділ",
            UaDescFirst = "Один працівник працює в одному відділі.",
            UaDescSecond = "Один відділ може мати багато співробітників."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "City",
            EnNameSecondTable = "Country",
            UaNameFirstTable = "Місто",
            UaNameSecondTable = "Країна",
            UaDescFirst = "Одне місто знаходиться в одній країні.",
            UaDescSecond = "В одній країні може бути багато міст."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Patient",
            EnNameSecondTable = "Hospital",
            UaNameFirstTable = "Пацієнт",
            UaNameSecondTable = "Лікарня",
            UaDescFirst = "Один пацієнт знаходиться в одній лікарні.",
            UaDescSecond = "В одній лікарні може бути багато пацієнтів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Movie",
            EnNameSecondTable = "Director",
            UaNameFirstTable = "Фільм",
            UaNameSecondTable = "Режисер",
            UaDescFirst = "Один фільм знятий одним режисером.",
            UaDescSecond = "Один режисер може знімати багато фільмів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Product",
            EnNameSecondTable = "Category",
            UaNameFirstTable = "Продукт",
            UaNameSecondTable = "Категорія",
            UaDescFirst = "Один продукт належить до однієї категорії.",
            UaDescSecond = "В одній категорії може бути багато продуктів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Article",
            EnNameSecondTable = "Magazine",
            UaNameFirstTable = "Стаття",
            UaNameSecondTable = "Журнал",
            UaDescFirst = "Одна стаття опублікована в одному журналі.",
            UaDescSecond = "В одному журналі може бути багато статей."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Song",
            EnNameSecondTable = "Playlist",
            UaNameFirstTable = "Пісня",
            UaNameSecondTable = "Плейліст",
            UaDescFirst = "Одна пісня належить до одного плейлиста.",
            UaDescSecond = "В одному плейлисті може бути багато пісень."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Software",
            EnNameSecondTable = "Developer",
            UaNameFirstTable = "Програмне забезпечення",
            UaNameSecondTable = "Розробник",
            UaDescFirst = "Одне програмне забезпечення розробляється одним розробником.",
            UaDescSecond = "Один розробник може розробити багато програмних додатків."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Property",
            EnNameSecondTable = "Owner",
            UaNameFirstTable = "Власність",
            UaNameSecondTable = "Власник",
            UaDescFirst = "Один об'єкт нерухомості належить одному власнику.",
            UaDescSecond = "Один власник може володіти багатьма об'єктами нерухомості."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Recipe",
            EnNameSecondTable = "Cookbook",
            UaNameFirstTable = "Рецепт",
            UaNameSecondTable = "Кулінарна книга",
            UaDescFirst = "Один рецепт є частиною однієї кулінарної книги.",
            UaDescSecond = "В одній кулінарній книзі може бути багато рецептів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Tool",
            EnNameSecondTable = "Workshop",
            UaNameFirstTable = "Інструмент",
            UaNameSecondTable = "Майстерня",
            UaDescFirst = "Один інструмент належить одній майстерні.",
            UaDescSecond = "Одна майстерня може мати багато інструментів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Event",
            EnNameSecondTable = "Organizer",
            UaNameFirstTable = "Подія",
            UaNameSecondTable = "Організатор",
            UaDescFirst = "Одна подія організовується одним організатором.",
            UaDescSecond = "Один організатор може організувати багато подій."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Pet",
            EnNameSecondTable = "Owner",
            UaNameFirstTable = "Домашній улюбленець",
            UaNameSecondTable = "Власник",
            UaDescFirst = "Одна тварина належить одному власнику.",
            UaDescSecond = "Один власник може мати багато домашніх тварин."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Athlete",
            EnNameSecondTable = "Team",
            UaNameFirstTable = "Спортсмен",
            UaNameSecondTable = "Команда",
            UaDescFirst = "Один спортсмен грає за одну команду.",
            UaDescSecond = "В одній команді може бути багато спортсменів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Building",
            EnNameSecondTable = "Architect",
            UaNameFirstTable = "Будівля",
            UaNameSecondTable = "Архітектор",
            UaDescFirst = "Одна будівля спроектована одним архітектором.",
            UaDescSecond = "Один архітектор може спроектувати багато будівель."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Photo",
            EnNameSecondTable = "Album",
            UaNameFirstTable = "Фотографія",
            UaNameSecondTable = "Альбом",
            UaDescFirst = "Одна фотографія належить одному альбому.",
            UaDescSecond = "В одному альбомі може бути багато фотографій."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Computer",
            EnNameSecondTable = "User",
            UaNameFirstTable = "Комп'ютер",
            UaNameSecondTable = "Користувач",
            UaDescFirst = "Один комп'ютер належить одному користувачу.",
            UaDescSecond = "У одного користувача може бути багато комп'ютерів."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Garden",
            EnNameSecondTable = "Plant",
            UaNameFirstTable = "Сад",
            UaNameSecondTable = "Рослина",
            UaDescFirst = "Один сад містить багато рослин.",
            UaDescSecond = "Рослина росте в одному саду."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Library",
            EnNameSecondTable = "Bookshelf",
            UaNameFirstTable = "Бібліотека",
            UaNameSecondTable = "Книжкова полиця",
            UaDescFirst = "Одна бібліотека має багато книжкових полиць.",
            UaDescSecond = "На одній книжковій полиці може бути багато книг."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Airport",
            EnNameSecondTable = "Flight",
            UaNameFirstTable = "Аеропорт",
            UaNameSecondTable = "Рейс",
            UaDescFirst = "Один аеропорт обслуговує багато рейсів.",
            UaDescSecond = "Рейс відбувається з одного аеропорту."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Museum",
            EnNameSecondTable = "Exhibit",
            UaNameFirstTable = "Музей",
            UaNameSecondTable = "Експонат",
            UaDescFirst = "Один музей містить багато експонатів.",
            UaDescSecond = "Експонат знаходиться в одному музеї."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Theater",
            EnNameSecondTable = "Performance",
            UaNameFirstTable = "Театр",
            UaNameSecondTable = "Вистава",
            UaDescFirst = "Один театр ставить багато вистав.",
            UaDescSecond = "Вистава проводиться в одному театрі."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Orchestra",
            EnNameSecondTable = "Instrument",
            UaNameFirstTable = "Оркестр",
            UaNameSecondTable = "Музичний інструмент",
            UaDescFirst = "Один оркестр складається з багатьох музичних інструментів.",
            UaDescSecond = "Музичний інструмент використовується в оркестрі."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Farm",
            EnNameSecondTable = "Animal",
            UaNameFirstTable = "Ферма",
            UaNameSecondTable = "Тварина",
            UaDescFirst = "На одній фермі живе багато тварин.",
            UaDescSecond = "Тварина живе на одній фермі."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "Restaurant",
            EnNameSecondTable = "Dish",
            UaNameFirstTable = "Ресторан",
            UaNameSecondTable = "Страва",
            UaDescFirst = "Один ресторан пропонує багато страв.",
            UaDescSecond = "Страва готується в одному ресторані."
        },
        new LabWorkVariant()
        {
            EnNameFirstTable = "University",
            EnNameSecondTable = "Faculty",
            UaNameFirstTable = "Університет",
            UaNameSecondTable = "Факультет",
            UaDescFirst = "Один університет має багато факультетів.",
            UaDescSecond = "Факультет належить до одного університету."
        }
    };
}