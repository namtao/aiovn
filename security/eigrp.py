from ospf import route_ospf
from ip import assign_ip, check_class_ipaddress


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