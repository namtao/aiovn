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



