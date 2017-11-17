
module IML.DeviceScannerDaemon.TestFixtures

open Fable.PowerPack
open IML.JsonDecoders

let toMap =
  Json.ofString
    >> Result.unwrapResult
    >> unwrapObject

let addObj = toMap """
{
  "ACTION": "add",
  "DEVLINKS": "/dev/disk/by-id/ata-VBOX_HARDDISK_VB304a0a0f-15e93f07-part1 /dev/disk/by-path/pci-0000:00:01.1-ata-1.0-part1",
  "DEVNAME": "/dev/sdb1",
  "DEVPATH": "/devices/pci0000:00/0000:00:01.1/ata1/host1/target1:0:0/1:0:0:0/block/sdb/sdb1",
  "DEVTYPE": "partition",
  "ID_ATA": "1",
  "ID_ATA_FEATURE_SET_PM": 1,
  "ID_ATA_FEATURE_SET_PM_ENABLED": 1,
  "ID_ATA_WRITE_CACHE": 1,
  "ID_ATA_WRITE_CACHE_ENABLED": 1,
  "ID_BUS": "ata",
  "ID_MODEL": "VBOX_HARDDISK",
  "ID_MODEL_ENC": "VBOX HARDDISK",
  "ID_PART_ENTRY_DISK": "8:16",
  "ID_PART_ENTRY_NUMBER": "1",
  "ID_PART_ENTRY_OFFSET": "2048",
  "ID_PART_ENTRY_SCHEME": "dos",
  "ID_PART_ENTRY_SIZE": "2048",
  "ID_PART_ENTRY_TYPE": "0x83",
  "ID_PART_TABLE_TYPE": "dos",
  "ID_PATH": "pci-0000:00:01.1-ata-1.0",
  "ID_PATH_TAG": "pci-0000_00_01_1-ata-1_0",
  "ID_REVISION": "1.0",
  "ID_SERIAL": "VBOX_HARDDISK_VB304a0a0f-15e93f07",
  "ID_FS_TYPE": "LVM2_member",
  "ID_SERIAL_SHORT": "VB304a0a0f-15e93f07",
  "ID_TYPE": "disk",
  "MAJOR": "8",
  "MINOR": "17",
  "SEQNUM": "1566",
  "SUBSYSTEM": "block",
  "TAGS": ":systemd:",
  "USEC_INITIALIZED": "842",
  "IML_SIZE": "81784832",
  "IML_SCSI_80": "80",
  "IML_SCSI_83": "83",
  "IML_IS_RO": "1",
  "DM_MULTIPATH_DEVICE_PATH": "1",
  "DM_LV_NAME": "swap",
  "DM_VG_NAME": "centos",
  "DM_UUID": "LVM-pV8TgNKMJVNrolJgMhVwg4CAeFFAIMC83IU1hvimWWlvmd5xQddtMIqRtjwOuKTz",
  "DM_SLAVE_MMS": "252:2",
  "DM_VG_SIZE": " 20946354176B"
}
"""

let removeObj = toMap """
{
  "ACTION": "remove",
  "DEVLINKS": "/dev/disk/by-id/ata-VBOX_HARDDISK_VB304a0a0f-15e93f07-part1 /dev/disk/by-path/pci-0000:00:01.1-ata-1.0-part1",
  "DEVNAME": "/dev/sdb1",
  "DEVPATH": "/devices/pci0000:00/0000:00:01.1/ata1/host1/target1:0:0/1:0:0:0/block/sdb/sdb1",
  "DEVTYPE": "partition",
  "ID_ATA": "1",
  "ID_ATA_FEATURE_SET_PM": 1,
  "ID_ATA_FEATURE_SET_PM_ENABLED": 1,
  "ID_ATA_WRITE_CACHE": 1,
  "ID_ATA_WRITE_CACHE_ENABLED": 1,
  "ID_BUS": "ata",
  "ID_MODEL": "VBOX_HARDDISK",
  "ID_MODEL_ENC": "VBOX HARDDISK",
  "ID_PART_ENTRY_DISK": "8:16",
  "ID_PART_ENTRY_NUMBER": "1",
  "ID_PART_ENTRY_OFFSET": "2048",
  "ID_PART_ENTRY_SCHEME": "dos",
  "ID_PART_ENTRY_SIZE": "2048",
  "ID_PART_ENTRY_TYPE": "0x83",
  "ID_PART_TABLE_TYPE": "dos",
  "ID_PATH": "pci-0000:00:01.1-ata-1.0",
  "ID_PATH_TAG": "pci-0000_00_01_1-ata-1_0",
  "ID_REVISION": "1.0",
  "ID_SERIAL": "VBOX_HARDDISK_VB304a0a0f-15e93f07",
  "ID_SERIAL_SHORT": "VB304a0a0f-15e93f07",
  "ID_TYPE": "disk",
  "MAJOR": "8",
  "MINOR": "17",
  "SEQNUM": "1566",
  "SUBSYSTEM": "block",
  "TAGS": ":systemd:",
  "USEC_INITIALIZED": "842"
}
"""

let createZdataset = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "72",
  "ZEVENT_HISTORY_DSID": "11",
  "ZEVENT_HISTORY_DSNAME": "testPool1/home",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "create",
  "ZEVENT_HISTORY_INTERNAL_STR": "",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createSecondZdataset = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "74",
  "ZEVENT_HISTORY_DSID": "69",
  "ZEVENT_HISTORY_DSNAME": "testPool1/backup",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "create",
  "ZEVENT_HISTORY_INTERNAL_STR": "",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let destroyZdataset = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "78",
  "ZEVENT_HISTORY_DSID": "11",
  "ZEVENT_HISTORY_DSNAME": "testPool1/home",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "destroy",
  "ZEVENT_HISTORY_INTERNAL_STR": "",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createZpool = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.pool_create",
  "ZEVENT_EID": "74",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "6",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "pool_create",
  "ZEVENT_TIME": "1509969418 848447782",
  "ZEVENT_TIME_NSECS": "848447782",
  "ZEVENT_TIME_SECS": "1509969418",
  "ZEVENT_TIME_STRING": "2017-11-06 03:56:58-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let importZpool = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.pool_import",
  "ZEVENT_EID": "74",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "pool_import",
  "ZEVENT_TIME": "1509969418 848447782",
  "ZEVENT_TIME_NSECS": "848447782",
  "ZEVENT_TIME_SECS": "1509969418",
  "ZEVENT_TIME_STRING": "2017-11-06 03:56:58-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

/// export pool userspace command
let exportZpool = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.pool_destroy",
  "ZEVENT_EID": "58",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "1",
  "ZEVENT_POOL_STATE_STR": "EXPORTED",
  "ZEVENT_SUBCLASS": "pool_destroy",
  "ZEVENT_TIME": "1509968607 577447782",
  "ZEVENT_TIME_NSECS": "577447782",
  "ZEVENT_TIME_SECS": "1509968607",
  "ZEVENT_TIME_STRING": "2017-11-06 03:43:27-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

/// destroy pool userspace command
let destroyZpool = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.pool_destroy",
  "ZEVENT_EID": "76",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "2",
  "ZEVENT_POOL_STATE_STR": "DESTROYED",
  "ZEVENT_SUBCLASS": "pool_destroy",
  "ZEVENT_TIME": "1509969598 22447782",
  "ZEVENT_TIME_NSECS": "22447782",
  "ZEVENT_TIME_SECS": "1509969598",
  "ZEVENT_TIME_STRING": "2017-11-06 03:59:58-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createZpoolProperty = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "72",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "multihost=0",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""
let resetZpoolProperty = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "72",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "multihost=1",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createZpoolPropertyTwo = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "72",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "failmode=1",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createZdatasetProperty = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "68",
  "ZEVENT_HISTORY_DSID": "11",
  "ZEVENT_HISTORY_DSNAME": "testPool1/home",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "canmount=0",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let resetZdatasetProperty = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "68",
  "ZEVENT_HISTORY_DSID": "11",
  "ZEVENT_HISTORY_DSNAME": "testPool1/home",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "canmount=1",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createZdatasetPropertyTwo = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "68",
  "ZEVENT_HISTORY_DSID": "11",
  "ZEVENT_HISTORY_DSNAME": "testPool1/home",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "readonly=1",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createSecondZdatasetProperty = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "80",
  "ZEVENT_HISTORY_DSID": "69",
  "ZEVENT_HISTORY_DSNAME": "testPool1/backup",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "canmount=1",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""

let createSecondZdatasetPropertyTwo = toMap """
{
  "IFS": "  ",
  "PATH": "/usr/bin:/bin:/usr/sbin:/sbin",
  "PWD": "/",
  "SHLVL": "1",
  "ZDB": "/sbin/zdb",
  "ZED": "/sbin/zed",
  "ZED_PID": "21671",
  "ZED_ZEDLET_DIR": "/etc/zfs/zed.d",
  "ZEVENT_CLASS": "sysevent.fs.zfs.history_event",
  "ZEVENT_EID": "80",
  "ZEVENT_HISTORY_DSID": "69",
  "ZEVENT_HISTORY_DSNAME": "testPool1/backup",
  "ZEVENT_HISTORY_HOSTNAME": "lotus-32vm6",
  "ZEVENT_HISTORY_INTERNAL_NAME": "set",
  "ZEVENT_HISTORY_INTERNAL_STR": "readonly=0",
  "ZEVENT_HISTORY_TIME": "1509969196",
  "ZEVENT_HISTORY_TXG": "88539",
  "ZEVENT_POOL": "testPool1",
  "ZEVENT_POOL_CONTEXT": "0",
  "ZEVENT_POOL_GUID": "0x2D28F440E514007F",
  "ZEVENT_POOL_STATE": "0",
  "ZEVENT_POOL_STATE_STR": "ACTIVE",
  "ZEVENT_SUBCLASS": "history_event",
  "ZEVENT_TIME": "1509969196 548447782",
  "ZEVENT_TIME_NSECS": "548447782",
  "ZEVENT_TIME_SECS": "1509969196",
  "ZEVENT_TIME_STRING": "2017-11-06 03:53:16-0800",
  "ZEVENT_VERSION": "0",
  "ZFS": "/sbin/zfs",
  "ZFS_ALIAS": "zfs-0.7.1-1",
  "ZFS_RELEASE": "1",
  "ZFS_VERSION": "0.7.1",
  "ZINJECT": "/sbin/zinject",
  "ZPOOL": "/sbin/zpool",
  "_": "/usr/bin/printenv"
}
"""
