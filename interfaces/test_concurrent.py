import time
from concurrent.futures import ThreadPoolExecutor

lst = []


def _square(x):
    time.sleep(1)
    for i in range(x):
        # print(i)
        lst.append(str(i))
    return lst


if __name__ == "__main__":
    start = time.time()

    with ThreadPoolExecutor() as executor:
        executor.map(_square, [2000] * 10)

    end = time.time()
    print(end - start)
    # print(lst)
