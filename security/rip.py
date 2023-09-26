from ip import assign_ip, check_class_ipaddress


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
