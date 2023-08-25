import re
from ipaddress import IPv4Address, IPv4Network

# show ip route
# C: ket noi truc tiep


class IPAddress:
    # Clean up user input and split into ip and mask
    # Accepted input format -> '192.168.1.4/24'
    def __init__(self, address):
        regex = "^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}/\d+$"
        if len(re.findall(regex, address)) == 1:
            ipstr, cidrstr = address.split("/")

            self._addr = ipstr.split(".")
            self._cidr = int(cidrstr)
        else:
            raise TypeError(
                "No valid IP address found in input. Please use format X.X.X.X/XX"
            )

    # Cleaning up IP address
    @property
    def address(self):
        return ".".join(map(str, self._addr))

    # For each bit in each octet (8 times), add a decreasing power of 2 to the octet (128,64,32,..)
    # Repeated 8 times = 255, repeated <8 times gives the final octet
    @property
    def mask(self):
        mask = [0 for x in range(4)]
        for i in range(self._cidr):
            mask[int(i / 8)] = mask[int(i / 8)] + (1 << (7 - i % 8))
        return ".".join(map(str, mask))

    # Updating subnet mask in format: X.X.X.X
    # Update Address.mask and Address._cidr by counting '1' in binary conversion of number
    @mask.setter
    def mask(self, new_mask):
        mask = new_mask.split(".")
        self._cidr = sum([bin(int(octet)).count("1") for octet in new_mask.split(".")])

    # Network address from ANDing IP address and subnet mask
    @property
    def network(self):
        net = [int(self._addr[i]) & int(self.mask.split(".")[i]) for i in range(4)]
        return ".".join(map(str, net))

    # Wildcard mask from XORing 255 with each octect of subnet mask
    # Then add wildcard mask to Network address to get broadcast address
    @property
    def broadcast(self):
        xor = [int(self.mask.split(".")[i]) ^ 255 for i in range(4)]
        broadcast = [int(self.network.split(".")[i]) + xor[i] for i in range(4)]
        return ".".join(map(str, broadcast))

    # Network addresses are always even -> Last bit is always 0. Simply add 1 to this to get the first address
    @property
    def first(self):
        first = [int(octet) for octet in self.network.split(".")]
        first[3] = first[3] ^ 1
        return ".".join(map(str, first))

    # Last usable address, start at first host bit of network address and flip bits to 1
    # Then AND last octet by 254
    @property
    def last(self):
        last = [int(octet) for octet in self.network.split(".")]
        for i in range(32 - self._cidr):
            last[int((self._cidr + i) / 8)] = last[int((self._cidr + i) / 8)] + (
                1 << (i % 8)
            )
        last[3] = last[3] & 254
        return ".".join(map(str, last))

    # Check to see if IP is in range: Network bits match
    # Expected usage: <string like 192.168.1.45> in Address
    def __contains__(self, addr):
        new = addr.split(".")
        net = [int(self._addr[i]) & int(self.mask.split(".")[i]) for i in range(4)]
        new_net = [int(new[i]) & int(self.mask.split(".")[i]) for i in range(4)]
        for i in range(4):
            if int(net[i]) != int(new_net[i]):
                return False
        return True

    # Print all information
    def get_all(self):
        print(
            f"""
                IP Address: {self.address}
                Subnet Mask: {self.mask}
                Network Address: {self.network}
                First Usable: {self.first}
                Last Usable: {self.last}
                Broadcast Address: {self.broadcast}
        """
        )

    # Return IP address
    def __str__(self):
        return self.address


def assign_ip(lst_route: list, lst_pc: list):
    def route_assign_ip(route: dict):
        lst = ["enable", "conf t"]

        for k, v in route.items():
            val = v.split("/")

            lst.extend(
                [
                    f"interface {k}",
                    f"ip address {val[0]} {IPAddress(v).mask}"
                    if (len(val) > 1)
                    else f"ip address {val[0]}",
                    "no sh" if ("lo" not in k) else "ip ospf network point-to-point",
                    "exit",
                ]
            )

        return "\n".join(lst)

    def linux_assign_ip(pc: tuple):
        return "\n".join(
            [
                "tc",
                "sudo su",
                f"ifconfig eth0 {pc[0]} up",
                f"route add default gw {pc[1]}",
            ]
        )

    # assign ip
    for index, r in enumerate(lst_route):
        print(f"R{index + 1}")
        print(route_assign_ip(r))
        print("\n\n")

    for index, pc in enumerate(lst_pc):
        print(f"PC{index + 1}")
        print(linux_assign_ip(pc))
        print("\n\n")


def prefixlen_to_wildcard(prefixlen: str):
    return str(
        IPv4Address(int(IPv4Address._make_netmask(prefixlen)[0]) ^ (2**32 - 1))
    )


def netmask_to_wildcard(netmask: str):
    return str(IPv4Address(int(IPv4Address(netmask)) ^ (2**32 - 1)))


def wildcard_to_netmask(wildcard: str):
    return str(IPv4Address(int(IPv4Address(wildcard)) ^ (2**32 - 1)))


def wildcard_to_prefixlen(wildcard: str):
    return IPv4Address._prefix_from_ip_int(int(IPv4Address(wildcard)) ^ (2**32 - 1))


def ip_to_binary(ip):
    return ".".join([bin(int(x) + 256)[3:] for x in ip.split(".")])


def binary_to_decimal(n):
    return int(n, 2)


def binary_to_ip(binary: str):
    return IPv4Address(".".join([str(binary_to_decimal(x)) for x in binary.split(".")]))


def subtract_ip(ip: list, test_condition: list):
    return [
        str(int(element1) - int(element2))
        for (element1, element2) in zip(ip, test_condition)
    ]


def sum_ip(ip: list, test_condition: list):
    return [
        str(int(element1) + int(element2))
        for (element1, element2) in zip(ip, test_condition)
    ]


# dinh tuyen tung doan 1
def route_static(route_line_src, route_line_des, routes: list):
    for index, r in enumerate(routes):
        if index + 1 < len(routes):
            print(f"\nR{index +1}")
            line_des = route_line_des.split("/")[0]
            sub_des = IPAddress(route_line_des).mask
            ip1 = list(routes[index + 1].values())[0].split("/")[0]
            print(f"ip route {line_des} {sub_des} {ip1}")

            print(f"\nR{index + 2}")
            line_des = route_line_src.split("/")[0]
            sub_des = IPAddress(route_line_src).mask
            ip2 = list(routes[index].values())[1].split("/")[0]
            print(f"ip route {line_des} {sub_des} {ip2}")


def chapter_5():
    R1 = {"giga 6/0": "192.168.10.254/24", "giga 0/0": "192.1.12.1/30"}

    R2 = {
        "giga 0/0": "192.1.12.2/30",
        "giga 1/0": "192.1.23.2/30",
        "giga 2/0": "dhcp",
    }

    R3 = {
        "giga 1/0": "192.1.23.1/30",
        "giga 6/0": "192.168.20.254/24",
    }

    PC1 = ("192.168.10.1/24", "192.168.10.254")
    PC2 = ("192.168.20.1/24", "192.168.20.254")

    # dinh tuyen tinh
    # phai duoc sap xep dung theo duong di
    # sort
    R = [R1, R2, R3]
    PC = [PC1, PC2]

    assign_ip(R, PC)

    route_static("192.168.10.0/24", "192.168.20.0/24", R)


def check_class_ipaddress(ipaddress):
    class_bit = int(ipaddress.split(".")[0])
    if class_bit < 128:
        return 1
    elif 128 <= class_bit < 192:
        return 2
    elif 192 <= class_bit < 224:
        return 3
    else:
        return 0


def route_rip(router):
    lst = ["router rip", "version 2", "no auto-summary"]

    for k, v in router.items():
        l = []
        if "dhcp" not in v:
            class_name = check_class_ipaddress(v)
            for i in range(class_name):
                l.append(v.split(".")[i])

            for i in range(4 - class_name):
                l.append("0")

            lst.append(f"network {'.'.join(l)}")

    lst.append("exit")
    return "\n".join(lst)


def chapter_6():
    R1 = {
        "giga 6/0": "192.168.10.254/24",
        "giga 0/0": "192.1.12.1/30",
    }

    R2 = {
        "giga 0/0": "192.1.12.2/30",
        "giga 1/0": "192.1.23.2/30",
        "giga 2/0": "dhcp",
    }

    R3 = {
        "giga 1/0": "192.1.23.1/30",
        "giga 6/0": "192.168.20.254/24",
    }

    PC1 = ("192.168.10.1/24", "192.168.10.254")
    PC2 = ("192.168.20.1/24", "192.168.20.254")

    R = [R1, R2, R3]
    PC = [PC1, PC2]

    assign_ip(R, PC)

    for index, r in enumerate(R):
        print(f"R{index}")
        print(route_rip(r))
        print("\n")


def route_ospf(routes: list, Zone_Ospf: dict):
    # so co the ngau nhien tu 1 => 65535
    index = 0

    # net_id = /24
    # host_id = 332/ net_id
    # 0: kiem tra
    # 1: khong kiem tra
    # chi kiem tra cac bit cua ohan net_id

    for r in routes:
        index += 1
        print(f"R{index}")
        lst = ["router ospf 1"]
        area = None
        network = None
        wildcard = None
        for k1, v1 in r.items():
            if "dhcp" not in v1:
                for k2, v2 in Zone_Ospf.items():
                    if v1 in v2:
                        area = k2
                        break
                network = IPAddress(v1).network
                wildcard = netmask_to_wildcard(IPAddress(v1).mask)

                if area is None:
                    raise Exception("Area None")

                lst.append(f"network {network} {wildcard} area {area}")
                # 30.0.0.0 0.0.3.255 area 0 co th thay the cho cong lo
            else:
                lst.append("default-information originate")

        lst.append("exit")
        print("\n".join(lst))


def chapter_7():
    R1 = {
        "giga 0/0": "100.0.0.1/24",
        "giga 3/0": "192.1.14.1/30",
        "giga 2/0": "dhcp",
    }

    R2 = {
        "giga 0/0": "100.0.0.2/24",
        "lo 0": "20.0.0.1/24",
        "lo 1": "20.0.1.1/24",
        "lo 2": "20.0.2.1/24",
        "lo 3": "20.0.3.1/24",
    }

    R3 = {
        "giga 0/0": "100.0.0.3/24",
        "lo 0": "30.0.0.1/24",
        "lo 1": "30.0.1.1/24",
        "lo 2": "30.0.2.1/24",
        "lo 3": "30.0.3.1/24",
    }

    R4 = {
        "giga 3/0": "192.1.14.2/30",
        "lo 0": "40.0.0.1/24",
        "lo 1": "40.0.1.1/24",
        "lo 2": "40.0.2.1/24",
        "lo 3": "40.0.3.1/24",
    }

    R = [R1, R2, R3, R4]
    Zone_Ospf = {
        0: [
            "100.0.0.1/24",
            "100.0.0.2/24",
            "100.0.0.3/24",
            "30.0.0.1/24",
            "30.0.1.1/24",
            "30.0.2.1/24",
            "30.0.3.1/24",
            "20.0.0.1/24",
            "20.0.1.1/24",
            "20.0.2.1/24",
            "20.0.3.1/24",
        ],
        1: [
            "192.1.14.1/30",
            "192.1.14.2/30",
            "40.0.0.1/24",
            "40.0.1.1/24",
            "40.0.2.1/24",
            "40.0.3.1/24",
        ],
    }
    assign_ip(R, [])
    route_ospf(R, Zone_Ospf)


def route_eigrp(router, as_number: int):
    lst = [f"router eigrp {as_number}", "no auto-summary"]

    for k, v in router.items():
        l = []
        if "dhcp" not in v:
            class_name = check_class_ipaddress(v)
            for i in range(class_name):
                l.append(v.split(".")[i])

            for i in range(4 - class_name):
                l.append("0")

            lst.append(f"network {'.'.join(l)}")

    lst.append("exit")
    result = []
    [result.append(x) for x in lst if x not in result]

    return "\n".join(result)


def chapter_8():
    R1_OSPF = {"giga 0/0": "100.0.0.1/24", "giga 2/0": "dhcp"}

    R2 = {
        "giga 0/0": "100.0.0.2/24",
        "lo 0": "20.0.0.1/24",
        "lo 1": "20.0.1.1/24",
        "lo 2": "20.0.2.1/24",
        "lo 3": "20.0.3.1/24",
    }

    R3 = {
        "giga 0/0": "100.0.0.3/24",
        "lo 0": "30.0.0.1/24",
        "lo 1": "30.0.1.1/24",
        "lo 2": "30.0.2.1/24",
        "lo 3": "30.0.3.1/24",
    }

    R4 = {
        "giga 3/0": "192.1.14.2/30",
        "serial 6/0": "200.0.0.2/24",
        "lo 0": "40.0.0.1/24",
        "lo 1": "40.0.1.1/24",
        "lo 2": "40.0.2.1/24",
        "lo 3": "40.0.3.1/24",
    }
    Zone_Ospf = {
        0: [
            "100.0.0.1/24",
            "100.0.0.2/24",
            "100.0.0.3/24",
            "30.0.0.1/24",
            "30.0.1.1/24",
            "30.0.2.1/24",
            "30.0.3.1/24",
            "20.0.0.1/24",
            "20.0.1.1/24",
            "20.0.2.1/24",
            "20.0.3.1/24",
        ]
    }

    R1_EIGRP = {
        "giga 3/0": "192.1.14.1/30",
        "serial 6/0": "200.0.0.1/24",
    }
    R1 = {**R1_EIGRP, **R1_OSPF}
    assign_ip([R1, R2, R3, R4], [])
    route_ospf([R1_OSPF, R2, R3], Zone_Ospf)
    print(f"R1 \n{route_eigrp(R1_EIGRP, 10)}")
    print(f"R4 \n{route_eigrp(R4, 10)}")
    print(
        "\n".join(
            [
                "R1",
                "router ospf 1",
                "redistribute eigrp 10 subnets",
                "exit",
                "router eigrp 10",
                "redistribute ospf 1 metric 100000 100 255 255 1500",
                # (băng thông, độ trễ, tải, độ tin cậy, mtu)
                "exit",
                # default route
                "router eigrp 10",
                "redistribute static",
                "exit",
            ]
        )
    )


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
            if ip < ip_end:
                print(f"access-list 1 permit {test_condition} {wildcard_mask}")
                test_condition = ip + 1
            else:
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
                    ".".join(sum_ip(str(test_condition).split("."), ["0", "0", "0", sub[-1]]))
                )
                wildcard_mask = ".".join(sub)
                print(f"access-list 1 permit {test_condition} {wildcard_mask}")
                
                test_condition = ip +1


access_list(IPv4Address("192.168.100.128"), IPv4Address("192.168.100.130"))