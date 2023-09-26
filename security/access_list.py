from ipaddress import IPv4Address

from ip import (binary_to_decimal, binary_to_ip, ip_to_binary, subtract_ip,
                sum_ip)


def access_list(ip_start: IPv4Address, ip_end: IPv4Address):
    test_condition = ip_start
    ip = ip_end
    wildcard_mask = None

    while test_condition <= ip_end:
        # neu 2 so ip bang nhau thi in ra va ket thuc
        if test_condition == ip_end:
            print(f"access-list 1 permit host {test_condition}")
            break

        binary_test_condition = ip_to_binary(str(test_condition))

        # neu bit cuoi cug la 1 thi +1 de ra so moi co bit cuoi cung la 0
        if binary_test_condition[-1] == "1":
            print(f"access-list 1 permit host {test_condition}")
            test_condition += 1
            continue
        else:
            # thay the tat ca cac bit cuoi tu 0 thanh 1 cho den khi gap 1
            index = -1
            bin = list(binary_test_condition)

            while binary_test_condition[index] == "0":
                bin[index] = "1"
                index -= 1

            binary_ip = "".join(bin)
            ip = binary_to_ip(binary_ip)

            subtracted = subtract_ip(str(ip).split("."), str(test_condition).split("."))
            wildcard_mask = ".".join(subtracted)

            # so sanh ip va ip_end
            if ip > ip_end:
                # neu lon hon thi phai tru
                lst = [128, 64, 32, 16, 8, 4, 2, 1]

                def lower_bound(x, l):
                    for i, y in enumerate(l):
                        if y <= x:
                            return l[i] - 1

                a = binary_to_decimal(binary_test_condition.split(".")[-1])
                # hieu cua ip_end va test_condition
                sub = subtract_ip(
                    str(ip_end).split("."), str(test_condition).split(".")
                )

                x = lower_bound(int(sub[-1]), lst)
                sub[-1] = str(x) if x != 0 else "1"

                ip = IPv4Address(
                    ".".join(
                        sum_ip(str(test_condition).split("."), ["0", "0", "0", sub[-1]])
                    )
                )
                wildcard_mask = ".".join(sub)

            print(f"access-list 1 permit {test_condition} {wildcard_mask}")
            test_condition = ip + 1
