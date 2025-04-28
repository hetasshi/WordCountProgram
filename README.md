# TextAnalyzer.cs - объяснялка на случай если забуду. Памятка

| Показатель | Где считается | Алгоритм / формула | Ключевой фрагмент кода |
|------------|---------------|--------------------|-------------------------|
| **`TotalWords`** | `CalculateWordStats` | 1. Разбиваем текст на список `words` (см. `ExtractWords`).<br>2. `TotalWords = words.Count;` | ```csharp\nTotalWords = words.Count;\n``` |
| **`TotalSentences`** | `CalculateSentenceStats` | 1. Делим текст на `sentences` по точке `.` / `!` / `?` (см. `ExtractSentences`).<br>2. `TotalSentences = sentences.Count;` | ```csharp\nTotalSentences = sentences.Count;\n``` |
| **`TotalSpaces`** | `CalculateCharStats` | Проходим каждый символ исходного `text`.<br> Если `c == ' '`, инкрементируем счётчик. | ```csharp\nif (c == ' ') TotalSpaces++;\n``` |
| **`TextSizeBytes`** | `Analyze` (самый верх метода) | Сразу после сброса: `Encoding.UTF8.GetByteCount(text)` — сколько байтов в UTF-8. | ```csharp\nTextSizeBytes = Encoding.UTF8.GetByteCount(text);\n``` |
| **`AvgWordLength`** | `CalculateWordStats` | Суммируем длины всех слов → делим на `TotalWords`, округляем до 1 знака. | ```csharp\nAvgWordLength = Math.Round((double)charSum / TotalWords, 1);\n``` |
| **`AvgSentenceLength`** | `CalculateWordStats` (после подсчёта слов) | Если есть хотя бы одно предложение: `TotalWords / TotalSentences`, округление до 1. | ```csharp\nif (TotalSentences > 0)\n    AvgSentenceLength = Math.Round((double)TotalWords / TotalSentences, 1);\n``` |
| **`WordFrequency`** (`_wordFreq`) | `CalculateWordStats` | Для каждого слова: берём текущее значение (0, если нет) и +1. | ```csharp\nint cur; _wordFreq.TryGetValue(word, out cur);\n_wordFreq[word] = cur + 1;\n``` |
| **`CharFrequency`** (`_charFreq`) | `CalculateCharStats` | Для каждого символа исходного текста — аналогично словарю слов. | ```csharp\nint cur; _charFreq.TryGetValue(c, out cur);\n_charFreq[c] = cur + 1;\n``` |

### Визуальная схема вызовов

```
Analyze(text)
 ├─ Reset()                     // все нули, словари очистить
 ├─ TextSizeBytes = UTF8(text)
 ├─ sentences = ExtractSentences(text)
 │   └─ TotalSentences
 ├─ words = ExtractWords(text)
 │   ├─ TotalWords
 │   ├─ AvgWordLength
 │   ├─ WordFrequency[…]
 │   └─ AvgSentenceLength = TotalWords / TotalSentences
 └─ foreach char in text
     ├─ TotalSpaces (если ' ')
     └─ CharFrequency[…]
```

### Главное про каждую «кучку» кода

* **ExtractSentences** — `Regex.Split` по шаблону `(?<=[.!?])` и `Trim()`, поэтому точки остаются в самом предложении, а пустые строки не попадают.
* **ExtractWords** — Unicode-регекс `[\\p{L}\\p{N}][\\p{L}\\p{N}\\p{Pd}]*` — букв/цифр + дефисы внутри слова.
* **Reset / Clear** — обнуляет всё, чтобы новый запуск анализа не «прихватил» старые данные.
* **Словари** хранятся в `Dictionary`-ах для быстрого подсчёта топ-10.

