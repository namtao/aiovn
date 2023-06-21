import multiprocessing as mp
import time

import numpy as np


def _square(x):
    time.sleep(1)    
    return x*x*x*x*x*x*x

def log_result(result):
    # Hàm được gọi bất kỳ khi nào _square(i) trả ra kết quả.
    # result_list được thực hiện trên main process, khong phải pool workers.
    global result_list
    result_list = np.append(result_list, result)

def apply_async_with_callback():
    pool = mp.Pool(processes=20)
    for i in range(200):
        print(i)
        pool.apply_async(_square, args = (i, ), callback = log_result)
    pool.close()
    pool.join()
    print(result_list)

if __name__ == '__main__':
    start = time.time()
    result_list = np.empty(0)
    apply_async_with_callback()
    end = time.time()
    print(end-start)