# WordCountProgram
### 1. Что в нём хранится

| **Имя поля / свойства** | Что это такое | Пример значения после анализа |
|-------------------------|--------------|--------------------------------|
| `TotalWords`            | Сколько слов нашлось | `152` |
| `TotalSpaces`           | Сколько пробелов | `151` |
| `TotalSentences`        | Сколько предложений (по «. ! ?») | `9` |
| `AvgWordLength`         | Средняя длина слова | `4,7` |
| `AvgSentenceLength`     | Среднее кол-во слов в предложении | `16,9` |
| `TextSizeBytes`         | Размер текста в байтах (UTF-8) | `873` |
| `_wordFreq`             | Словарь «слово → сколько раз» | `{ "и": 23, "дом": 5, … }` |
| `_charFreq`             | Словарь «символ → сколько раз» | `{ 'а': 45, '😀': 3, … }` |

---

### 2. Главная кнопка — `Analyze(string text)`

```csharp
public void Analyze(string text)
{
    if (string.IsNullOrEmpty(text))
        throw new ArgumentException("Текст не должен быть пустым.");

    Reset();                               // обнуляем старые данные
    TextSizeBytes = Encoding.UTF8.GetByteCount(text);

    var sentences = ExtractSentences(text); // режем на предложения
    CalculateSentenceStats(sentences);

    var words = ExtractWords(text);         // режем на слова
    CalculateWordStats(words);

    CalculateCharStats(text);               // считаем символы/пробелы
}
```

* **`Reset()`** — всё к нулям, чистим словари.  
* Размер берём через **UTF-8** — так любые символы (русский, эмодзи) считаются правильно.  

---

### 3. Разрезаем текст

| Метод | Что делает | Ключевая строка кода |
|-------|------------|----------------------|
| `ExtractSentences` | Делит по «. ! ?» | `Regex.Split(text, "(?<=[.!?])")` |
| `ExtractWords`     | Ищет слова «буквы/цифры-дефисы» | Шаблон `[\\p{L}\\p{N}][\\p{L}\\p{N}\\p{Pd}]*` |

* `\p{L}` — любая буква Unicode, `\p{N}` — цифра, `\p{Pd}` — дефис.  
* То есть «e-mail» считается **одним** словом, «2024» тоже словом.

---

### 4. Считаем цифры

#### 4.1 По словам

```csharp
foreach (string w in words)
{
    charSum += w.Length;                // считаем символы
    _wordFreq[w] = _wordFreq.ContainsKey(w) ? _wordFreq[w] + 1 : 1;
}

AvgWordLength = Math.Round((double)charSum / TotalWords, 1);
```

*После цикла* знаем `TotalWords` и `AvgWordLength`.  
Если уже известен `TotalSentences`, делим и получаем `AvgSentenceLength`.

#### 4.2 По символам

```csharp
foreach (char c in text)
{
    if (c == ' ') TotalSpaces++;        // пробелы отдельно
    _charFreq[c] = _charFreq.ContainsKey(c) ? _charFreq[c] + 1 : 1;
}
```

---

### 5. Полный сброс — метод `Clear()`

```csharp
public void Clear()  // вызываем при нажатии «Очистить»
{
    Reset();         // просто всё обнуляем — без «пустого» анализа
}
```

Теперь при очистке в статистике **всё по нулям**, а не «1 пробел / 1 байт».

---

### 6. Кратко в одну картинку

```
Analyze(text)
 ├─ Reset()
 ├─ TextSizeBytes = UTF8(text)
 ├─ sentences = Regex.Split(text, ".!?")
 │   └─ TotalSentences
 ├─ words = Regex.Matches(text, pattern)
 │   └─ TotalWords, AvgWordLength, WordFrequency
 └─ foreach char in text
     └─ TotalSpaces, CharFrequency
     └─ Получаем AvgSentenceLength
```

Вот и всё: класс берёт строку, режет её на кусочки, складывает счётчики и отдаёт готовую статистику форме.
