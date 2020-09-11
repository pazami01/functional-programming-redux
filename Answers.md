# Worksheet Ten

## Question 4:

System.LINQ.Enumerable extension methods that would benefit from returning an Option<T> instead:

### Aggregate<TSource>

To avoid throwing InvalidOperationException.

### Enumerable.Average

To avoid throwing InvalidOperationException or returning a nullable type.

### Enumerable.Cast

Could return None if an element cannot be casted.

### Enumerable.ElementAt

Could return None instead of throwing ArgumentOutOfRangeException.

### Enumerable.First
### Enumerable.Last

Return None instead of throwing InvalidOperationException if the source is empty. Or if no element satisfies the predicate.

### Enumerable.Max

To avoid throwing InvalidOperationException or returning a nullable type.

### Enumerable.Min

To avoid throwing InvalidOperationException or returning a nullable type.

### Enumerable.Range
### Enumerable.Repeat

Return None instead of ArgumentOutOfRangeException.

### Enumerable.Single

To avoid throwing InvalidOperationException.

### Enumerable.Sum

Instead of returning nullable.

## Question 5:

...





