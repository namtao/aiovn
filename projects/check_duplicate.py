from collections import Counter


def check_duplicate(arr):
    return {item for item, count in Counter(arr).items() if count > 1}

# lstDuplicate = list(set(lst1) & set(lst2))
