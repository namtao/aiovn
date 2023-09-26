from ip import IPAddress, assign_ip


# dinh tuyen tung doan 1
def route(route_line_src, route_line_des, routes: list):
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

    route("192.168.10.0/24", "192.168.20.0/24", R)
